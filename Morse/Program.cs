using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morse
{
    class Program
    {
        static void Main(string[] args)
        {
            Screen sc = new Screen();
        }
        class ConvertToMorse
        {
            string _input;

            public ConvertToMorse(string input)
            {
                _input = input;
                toMorse();//calling to morse from constructor as it cant be called implicetly, and since output is set there
            }

            string Input
            {
                get => _input;
            }

            string Output
            {
                get; set;
            }

            void toMorse()
            {
                string input = Input.ToLower();
                string output = "";

                foreach(char inp in input)//i forgot that every single character in string is classified as char and not string
                {
                    switch (inp)
                    {
                        case 'a':
                            output += ".- ";
                            break;
                        case 'b':
                            output += "-... ";
                            break;
                        case 'c':
                            output += "-.-. ";
                            break;
                        case 'd':
                            output += "-.. ";
                            break;
                        case 'e':
                            output += ". ";
                            break;
                        case 'f':
                            output += "..-. ";
                            break;
                        case 'g':
                            output += "--. ";
                            break;
                        case 'h':
                            output += ".... ";
                            break;
                        case 'i':
                            output += ".. ";
                            break;
                        case 'j':
                            output += ".--- ";
                            break;
                        case 'k':
                            output += "-.- ";
                            break;
                        case 'l':
                            output += ".-.. ";
                            break;
                        case 'm':
                            output += "-- ";
                            break;
                        case 'n':
                            output += "-. ";
                            break;
                        case 'o':
                            output += "--- ";
                            break;
                        case 'p':
                            output += ".--. ";
                            break;
                        case 'q':
                            output += "--.- ";
                            break;
                        case 'r':
                            output += ".-. ";
                            break;
                        case 's':
                            output += "... ";
                            break;
                        case 't':
                            output += "- ";
                            break;
                        case 'u':
                            output += "..- ";
                            break;
                        case 'v':
                            output += "...- ";
                            break;
                        case 'w':
                            output += ".-- ";
                            break;
                        case 'x':
                            output += "-..- ";
                            break;
                        case 'y':
                            output += "-.-- ";
                            break;
                        case 'z':
                            output += "--.. ";
                            break;
                        case '0':
                            output += "----- ";
                            break;
                        case '1':
                            output += ".---- ";
                            break;
                        case '2':
                            output += "..--- ";
                            break;
                        case '3':
                            output += "...-- ";
                            break;
                        case '4':
                            output += "....- ";
                            break;
                        case '5':
                            output += "..... ";
                            break;
                        case '6':
                            output += "-.... ";
                            break;
                        case '7':
                            output += "--... ";
                            break;
                        case '8':
                            output += "---.. ";
                            break;
                        case '9':
                            output += "----. ";
                            break;
                        
                        default:
                            output += "  ";
                            break;
                        
                    }
                }
                Output = output;
            }

            public override string ToString()
            {
                return Output;
            }
        }

        class Screen : Form
        {
            public Screen()
            {
                this.SetBounds(500, 300, 400, 400);
                this.Font = new Font("Arial", 11, FontStyle.Bold);
                this.BackColor = Color.FromArgb(20,20,20);
                this.ForeColor = Color.FromArgb(230,230,230);
                this.ResizeRedraw = false;
                this.Icon = new Icon(@"../../icon/icon.ico");
                this.Text = "Morse Code Converter";

                Label inputLabel = new Label();
                inputLabel.Text = "Input:";
                inputLabel.SetBounds(20, 20, 90, 30);

                Label outputLabel = new Label();
                outputLabel.Text = "Output:";
                outputLabel.SetBounds(20, 140, 90, 30);

                TextBox input = new TextBox();
                input.SetBounds(110, 20, 250, 100);
                input.Multiline = true;
                input.Font = new Font("Arial", 11);

                TextBox output = new TextBox();
                output.SetBounds(110, 140, 250, 100);
                output.Multiline = true;
                output.Font = new Font("Arial", 15, FontStyle.Bold);
                output.ReadOnly = true;

                Button convert = new Button();
                convert.Text = "Convert";
                convert.SetBounds(280, 300, 80, 30);
                convert.BackColor = Color.FromArgb(255, 179, 0);
                convert.ForeColor = Color.FromArgb(30, 30, 30);
                convert.Click += (sender, evnt) => {
                    ConvertToMorse b = new ConvertToMorse(input.Text);
                    output.Text = b.ToString();
                };

                Button play = new Button();
                play.Text = "Play";
                play.SetBounds(20, 300, 80, 30);
                play.BackColor = Color.FromArgb(30, 230, 30);
                play.ForeColor = Color.FromArgb(30, 30, 30);
                play.Click += (sender, evnt) => {
                    audioPlayer player = new audioPlayer(output.Text);
                };

                Button exit = new Button();
                exit.Text = "Exit";
                exit.SetBounds(140, 300, 80, 30);
                exit.BackColor = Color.FromArgb(220, 30,30);
                exit.Click += (s, e) => Application.Exit();


                this.Controls.Add(inputLabel);
                this.Controls.Add(outputLabel);
                this.Controls.Add(input);
                this.Controls.Add(output);
                this.Controls.Add(convert);
                this.Controls.Add(play);
                this.Controls.Add(exit);

                this.Show();
                Application.Run(this);
            }
        }

        class audioPlayer
        {
            string _morse;

            public audioPlayer(string morse)
            {
                _morse = morse;
                player();
            }

            string Morse
            {
                get => _morse;
            }

            void player()
            {
                string morse = Morse;//no need for this step btw just to not get confused.
                SoundPlayer dot = new SoundPlayer(@"../../Sounds/dot.wav");
                SoundPlayer dash = new SoundPlayer(@"../../Sounds/dash.wav");
                SoundPlayer blank = new SoundPlayer(@"../../Sounds/blank.wav");

                foreach(char a in morse)
                {
                    try
                    {
                        switch (a)
                        {
                            case '.':
                                dot.Play();
                                Thread.Sleep(500);
                                break;
                            case '-':
                                dash.Play();
                                Thread.Sleep(500);
                                break;
                            case ' ':
                                blank.Play();
                                Thread.Sleep(500);
                                break;
                            default:
                                blank.Play();
                                Thread.Sleep(500);
                                break;

                        }
                    }
                    catch
                    {
                        Console.WriteLine($"ERROR, FILE NOT FOUND at {dot.SoundLocation}.");
                    }
                }
            }
        }
    }
}
