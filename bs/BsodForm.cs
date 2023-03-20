using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bs
{
	public partial class BsodForm : Form
	{
		/// <summary>
		/// The duration the BSOD will be shown for. After this duration, its opacity is gradually reduced.
		/// </summary>
		private const int bsodVisibilityDurationMs = 4000;
		/// <summary>
		/// Time between the start of the application and when it will start listening for mouse input.
		/// </summary>
		private const int listenForMouseMovementDelayMs = 2000;

		private Timer updateTimer = new Timer();
		private Point initialCursorPosition;
		private List<FullscreenColor> fullscreenColorForms = new List<FullscreenColor>();
		private int percent = 0;
		private Random rand = new Random();
		private int percentacetick;
		private string Text2;
		private string PercentText;
        public BsodForm(Color backgroundColor, string smileyText, string text2, string percentText, string text3, string text4, string text5,int maxpercentacetick)
		{
			percentacetick = maxpercentacetick;
			InitializeComponent();
			Text2 = text2;
			PercentText = percentText;

            updateTimer.Interval = 50;
			updateTimer.Tick += ListenForMouseMovement;
			this.BackColor = backgroundColor;
			this.Smiley.Text = smileyText;
			this.errorText1.Text = text2 + "\n\n0" + percentText;
			this.error2.Text = text3 + "\n\n" + text4 + "\n" + text5;
			this.GotFocus += (object sender, EventArgs e)=>  Cursor.Hide();
			//this.LostFocus += (object sender, EventArgs e) => Cursor.Show();

			EnableMouseMovementMonitoring();
			

        }

		protected override void OnKeyDown(KeyEventArgs e)
		{
            
            if (e.KeyCode == Keys.Escape)
			{
				Application.Exit();
                Cursor.Show();
            }
			else
			{
				base.OnKeyDown(e);
			}
		}

		/// <summary>
		/// Begin monitoring mouse movement after a delay has expired.
		/// </summary>
		private async void EnableMouseMovementMonitoring()
		{
			await Task.Delay(listenForMouseMovementDelayMs);

			initialCursorPosition = Cursor.Position;
			updateTimer.Start();
		}

		private async void ListenForMouseMovement(object sender, System.EventArgs e)
		{
            
            if (Cursor.Position != initialCursorPosition)
			{
                //The position of the cursor has moved, which likely means that the user is using the computer.
                ShowBsod();
				updateTimer.Tick -= ListenForMouseMovement;
				await Task.Delay(bsodVisibilityDurationMs);
				updateTimer.Tick += FadeFormOpacity;
				
                
            }
		}
		
		/// <summary>
		/// Fade out opacity of all visible forms.
		/// This tells the user to stop panicking and that the BSOD is not real.
		/// </summary>
		private void FadeFormOpacity(object sender, System.EventArgs e)
		{
			if (rand.Next(10) == 1) { 

				percent += rand.Next(percentacetick);
				if(percent > 100)
				{
					percent = 100;
				}
                this.errorText1.Text = Text2 + "\n\n" + percent + PercentText;
				
            }
			if (percent > 99)
			{
				this.Opacity -= 0.02;
				foreach (var form in fullscreenColorForms)
				{
					form.Opacity = this.Opacity;
				}

				if (this.Opacity <= 0.0)
				{
					Application.Exit();
					Cursor.Show();
				}
			}
		}
		Font smileyFont;
        Font textFont;
		Font smalltextFont;
        FontFamily fontFamily = new FontFamily("Segoe UI");

		private void showBsodOnScreen(Screen screen)
		{
            this.Location = screen.Bounds.Location;//new Point(0, 0);

			this.Size = screen.Bounds.Size;
            CenterBsodText();
            smileyFont = new Font(
                fontFamily,
                this.Width / 9,
                FontStyle.Regular,
                GraphicsUnit.Pixel);

            Smiley.Font = smileyFont;

            textFont = new Font(
                fontFamily,
                this.Width / 54,
                FontStyle.Regular,
                GraphicsUnit.Pixel);

            errorText1.Font = textFont;

            smalltextFont = new Font(
                fontFamily,
                this.Width / 63,
                FontStyle.Regular,
                GraphicsUnit.Pixel);
            error2.Font = smalltextFont;
            qrcode.Size = new Size(this.Width / 12, this.Width / 12);
			
            
        }
        private void ShowBsod()
		{
			
			foreach (Screen screen in Screen.AllScreens)
			{
				if (screen.Primary)
				{
                    
                    showBsodOnScreen(screen);

                }
				else
				{
					//Make a new form which makes all non-primary screens black.
					var form = new FullscreenColor(Color.Black, screen.Bounds.Size, screen.Bounds.Location);
					form.Show();
					fullscreenColorForms.Add(form);
				}
			}

			this.Show();
			//Keep keyboard focus on main form so that pressing escape is captured properly.
			this.Focus();
            

		/// <summary>
		/// Makes the BSOD text centered in the form, using the form's size.
		/// </summary>
		private void CenterBsodText()
		{
			int halfBsodWidth = Smiley.Width / 2;
			int halfFormWidth = this.Width / 9;
			int halfBsodHeight = Smiley.Height / 2;
			int halfFormHeight = this.Height / 9;

			Point smileyPosition = new Point();
            smileyPosition.X = halfFormWidth - this.Width / 40;
            smileyPosition.Y = halfFormHeight;

            Smiley.Location = smileyPosition;

            Point errorPosition = new Point();
            errorPosition.X = halfFormWidth;
            errorPosition.Y = (int)(halfFormHeight*3.5f);

            errorText1.Location = errorPosition;
            errorText1.MaximumSize = new Size((int)(this.Width / 1.5f), 1000);
            errorText1.AutoSize = true;

            Point errorPosition2 = new Point();
			errorPosition2.X = (int)(halfFormWidth * 1.8f);
            errorPosition2.Y = (int)(halfFormHeight * 6.5f);

            error2.Location = errorPosition2;

            Point qrcodePosition = new Point();
            qrcodePosition.X = halfFormWidth;
            qrcodePosition.Y = (int)(halfFormHeight * 6.5f);
			qrcode.Location = qrcodePosition;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
