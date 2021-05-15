using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Accord;
using Accord.Video.FFMPEG;
using Accord.Video;



namespace kuzem_videoDeneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_openFile_Click(object sender, EventArgs e)
        {
            VideoFileReader reader = new VideoFileReader();
            // open video file
            //reader.Open(@"C:\Users\Ömer ÜNEŞİ\Source\Repos\kuzem_videoDeneme\kuzem_videoDeneme\Video.mp4");

            using (var vFReader = new VideoFileReader())
            {
                int adet = 0;
                int[] redBitmap = new int[2000];
                int control_re = new Color().R;
               
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.ShowDialog();
                vFReader.Open(openFile.FileName);
                
                
                //Bitmap btm_ref = new Bitmap(@"C:\Users\Ömer ÜNEŞİ\Source\Repos\kuzem_videoDeneme\kuzem_videoDeneme\picture.bmp");
                
                for (int i = 0; i < vFReader.FrameCount; i += 24)
                {
                    Bitmap bmpBaseOriginal = vFReader.ReadVideoFrame();
                    //if (bmpBaseOriginal == null)
                    //    continue;
                    for (int j = 0; j < vFReader.Width; j++)
                    {
                        for (int k = 0; k < vFReader.Height; k++)
                        {
                            control_re = bmpBaseOriginal.GetPixel(j, k).R;
                            redBitmap[j] += control_re;
                        }
                    }
                }

                for (int i = 1; i < vFReader.FrameCount; i += 24)
                {
                    if (redBitmap[i - 1] == redBitmap[i])
                    {
                        adet++;
                    }
                }
                vFReader.Close();
                MessageBox.Show(adet.ToString());
            }
        }
    }
}
