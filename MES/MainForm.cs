
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Timers;
using System.Threading;
namespace MES
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			RETRY:
			
			try{
				TimeSpan ts;
				
			var d1 = DateTime.Now;
				int file_counter = 0;
            do {		
              Thread.Sleep(20000);
              file_counter = Directory.GetFiles(@"C:\Nice try", "*.tar").Length;
             // file_counter = Directory.GetFiles(@"C:\Users\plyskay\Documents\SharpDevelop Projects\MES\Tars", "*.tar").Length;
              var d2 = DateTime.Now.AddSeconds(35.0d);
              ts = d2-d1;
              double r = ts.TotalSeconds;
              if(r >= 60)
              {
              	parse();
              	d1 = DateTime.Now;
              }
              
               
				} while (file_counter <= 7);
			} catch(Exception ex){
				MessageBox.Show(ex.ToString());
			}
	   
			  parse();
            goto RETRY;
		
		}

		 static void parse() {
        string[] filePaths = Directory.GetFiles(@"C:\Nice try", "*.tar");
         // string[] filePaths = Directory.GetFiles(@"C:\Users\plyskay\Documents\SharpDevelop Projects\MES\Tars", "*.tar");
      //  if (filePaths.Length >= 7) {
                int failed = 0;
                foreach (string file in filePaths) {
                    string filebody = File.ReadAllText(file);
                    if (filebody.Contains("\r\nTF\r\n")) {
                        failed++;
                    }
                }
              
                if (failed >= 7) {
                	//const string foldername = (@"C:\Users\plyskay\Documents\SharpDevelop Projects\MES\Trash");
                	//string [] trash = Directory.GetFiles(@"C:\Users\plyskay\Documents\SharpDevelop Projects\MES\Trash", "*.tar");
                	 const string foldername = (@"C:\Nice try\Trash");
                	 string [] trash = Directory.GetFiles(@"C:\Nice try\Trash", "*.tar");
                	  foreach( var y in trash){
                       //	File.SetAttributes(y, FileAttributes.Normal);
                       if (File.Exists(y)) {
								File.Delete(y);
							}
						}
                    foreach (string s in filePaths) {
                      
                        if (!Directory.Exists(foldername)) {
                            Directory.CreateDirectory(foldername);
                        }
                      
                       var fi = new FileInfo(s);
                        
                        File.Move(fi.FullName, Path.Combine(foldername, fi.Name));
                       
                    }
                	 
                    foreach( var y in trash){
                       //	File.SetAttributes(y, FileAttributes.Normal);
                       if (File.Exists(y)) {
								File.Delete(y);
							}
						}
                    
                    //filePaths.ToList().ForEach(s => File.Move(s, @"C:\Users\bornov\Documents\gyurko5\bin\Debug\tars result2"));
                } else {
                    foreach (string s in filePaths) {
                       const string foldername = @"C:\tars";
                       //const string foldername = (@"C:\Users\plyskay\Documents\SharpDevelop Projects\MES\PASS");
                        if (!Directory.Exists(foldername)) {
                            Directory.CreateDirectory(foldername);
                        }
                        
                        var fi = new FileInfo(s);
                        File.Move(fi.FullName, Path.Combine(foldername, fi.Name));
                    }
                }
                    
                    //filePaths.ToList().ForEach(s => File.Move(s, @"C:\Users\uu\Documents\gyurko5\bin\Debug\tars result3"));
      //          }
		
	}
//		
//		public enum State
//{
//    Idle = 0,
//    Processing = 1,
//    Stop = 100,
//}
//public void Run()
//{
//    State state = State.Idle;   // could be a member variable, so a service could stop this too
//
//    double intervalInSeconds = 10;
//    System.DateTime nextExecution = System.DateTime.Now.AddSeconds(intervalInSeconds);
//    while (state != State.Stop)
//    {
//        switch (state)
//        {
//            case State.Idle:
//                {
//                    if (nextExecution > System.DateTime.Now)
//                    {
//                        state = State.Processing;
//                    }
//                }
//                break;
//            case State.Processing:
//                {
//                	parse();
//                    // do your once-per-minute code here
//
//                    // if you want it to stop, just set it state to stop.
//                    // if this was a service, you could stop execution by setting state to stop, also
//                    // only time it would not stop is if it was waiting for the process to finish, which you can handle in other ways
//
//                    state = State.Idle;
//                    nextExecution = System.DateTime.Now.AddSeconds(intervalInSeconds);
//                }
//                break;
//            default:
//                break;
//        }
//
//        System.Threading.Thread.Sleep(1);
//    }
//}
}
}
