/*
 * Created by SharpDevelop.
 * User: toby
 * Date: 3/26/2013
 * Time: 2:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace overlay_publish_log
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		
		//global
		
		string selected_path="defaultmainform";
		
		List<string> site_labels= new List<string>();
		List<string> site_paths= new List<string>();
		List<RadioButton> arrList = new List<RadioButton>();
		
		
		OverlayForm ovf; 
		
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			init_data();
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
				
			//MessageBox.Show(" about to show overlay : selected_path="+selected_path);
			
			 ovf = new OverlayForm();
		     
		    ovf.sitepath=selected_path;
		    
		    
		    
		    
		    DateTime start_range=dateTimePicker1.Value;
		    DateTime end_range=dateTimePicker2.Value;
		    
		    ovf.init_data(start_range,end_range);
			ovf.Show();
		}
		
		protected void site_picked(object sender, EventArgs e) {
			//MessageBox.Show("site picked");
			// int selected_index =0;
			
			RadioButton[] cb = arrList.ToArray();
			for (int i = 0; i < site_labels.Count; i++)
				{
					
				    if (cb[i].Checked){
				   
				     selected_path = site_paths[i];
				     label1.Text = "data file: \n"+site_paths[i];
				    }
				   
				}
				
			
		}
		
		
		
		void init_data(){
			 
			
			List<string> labels= new List<string>();
			List<string> datestrs= new List<string>();
			List<string> descriptions= new List<string>();


			string best_path="P:\\Kimon\\data\\sites_data.csv";
            string offline_path="localdata\\sites_data.csv";
            string use_path=offline_path;
			
            if (File.Exists(best_path)){
            	use_path=best_path;
            	File.Delete(offline_path);
            	File.Copy(best_path,offline_path);
            }
			
            
            string best_algo_path="P:\\Kimon\\data\\algo_log.csv";
            string offline_algo_path="localdata\\algo_log.csv";
            string use_algo_path=offline_algo_path;
			
            if (File.Exists(best_algo_path)){
            	use_algo_path=best_algo_path;
            	File.Delete(offline_algo_path);
            	File.Copy(best_algo_path,offline_algo_path);
            }
            
            
            
            //init dates
            dateTimePicker1.Value = DateTime.Today.AddDays(-30);
            
            
			
             label1.Text="use_path="+ use_path;
            
				//begin load sites data
			try
		        {
		            using (StreamReader sr = new StreamReader(use_path))
		            {
		            	
		            	
		            	
		            	int count=0;
		            	String line="1";
		            	
		            	/*string[] label_arr=null;
		            	string[] datestr_arr=null;
		            	string[] description_arr=null;
		            	*/
		            	
		            	
		            	
		            	
		            	
		            	while ( line != null ){
		            		
		            		line=sr.ReadLine();
		            		
		            		
		            		if (count!=0){ 
		            			// only do stuff after first row (headers)
		            			string[] dataset= line.Split(';');
		            	
		            			
		            			
		            			//dataset is uniform and valid here
		            			String sitelabel = dataset[0];
		            			String sitepath = dataset[1];
		            			
		            			site_labels.Add(sitelabel);
		            			site_paths.Add(sitepath);
		            			
		            		} //end if not at 0
		            		
		            		count++;
		            	} //end while
		            	
		            } 	//End  using
		            
			}  catch (Exception iex2)
		        {
				  //MessageBox.Show(iex2.Message);
		        }
			//end load sites data
			// label1.Text="site count="+site_labels.Count;
			//// draw the checkboxes for sites ow
			
			  
				for (int j = 0; j < site_labels.Count; j++)
				{
				    RadioButton check = new RadioButton();
				    arrList.Add(check);
				}
				RadioButton[] cb = arrList.ToArray();
				
				for (int i = 0; i < site_labels.Count; i++)
				{
					cb[i].Text = site_labels[i];
				    cb[i].Location = new System.Drawing.Point(10, 15 + i * 20);
				    cb[i].BackColor = System.Drawing.Color.Silver;
				    cb[i].Name = site_labels[i];
				    cb[i].Size = new System.Drawing.Size(100, 17);
				    cb[i].CheckedChanged +=site_picked;
				    if (i==0){
				    cb[i].Checked = true;
				    selected_path= site_paths[i];
				    }
				    groupBox1.Controls.Add(cb[i]);
				}
			
			//end draw checkboxes
			  
						
						
						
				
		/*					
			try
		        {
		            using (StreamReader sr = new StreamReader("publish_log.csv"))
		            {
		            	
		            	int count=0;
		            	String line="1";
		            	
		            	
		            	
		            	
		            	
		            		
		            	
		            	while ( line != null ){
		            		
		            		line=sr.ReadLine();
		            		
		            		
		            		if (count!=0){ 
		            			// only do stuff after first row (headers)
		            			string[] dataset= line.Split(';');
		            			
		            			int runaway_cap=0;
		            			while (dataset.Length !=4 && runaway_cap < 1000){
		            				
		            			 	String another_line=sr.ReadLine();
		            			 	
		            			 	dataset = (line+another_line).Split(';');
		            			 	
		            			 	 runaway_cap++;
		            			 	
		            			} 
		            			  //continue on
		            			//MessageBox.Show("feilds="+dataset.Length.ToString());
		            			
		            			
		            			
		            			//dataset is uniform and valid here
		            			String label = dataset[0];
		            			String datestr = dataset[1];
		            			String description = dataset[3];
		            			
		            			//checking if we almost have a date signature for 201*-**-**
		            			if (datestr.Contains("201")  ){
		            			
		            		     labels.Add(label);
		            		     datestrs.Add(datestr);
		            		     descriptions.Add(datestr);
		            			}
		            			
		            			//MessageBox.Show("label="+label+ " date="+datestr);
		            			
		            		}
		            		
		            		count++;
		            	} //end while
		            	
		                String bigstr = sr.ReadToEnd();
		               // Console.WriteLine(line);
		               MessageBox.Show(bigstr);
		            }
		        }
		        catch (Exception iex)
		        {
		           // Console.WriteLine("The file could not be read:");
		           // Console.WriteLine(e.Message);
		           //MessageBox.Show(iex.Message);
		        }
		        
		        
		        string last=datestrs[datestrs.Count-1];
		        string first=datestrs[0];
		       
		       
		        
		       // string dateString = "5/1/2008 8:30:52 AM";
		       string[] parts =first.Split('-');
		       string dateString1 = parts[1]+"/"+parts[2]+"/"+parts[0]+" 8:00:01 AM";
		        DateTime d1 = DateTime.Parse(dateString1, System.Globalization.CultureInfo.InvariantCulture);
		       
		          
		          parts = last.Split('-');
		       string dateString2 = parts[1]+"/"+parts[2]+"/"+parts[0]+" 8:00:01 AM";
		       
             DateTime d2= DateTime.Parse(dateString2, System.Globalization.CultureInfo.InvariantCulture); 
		    
             TimeSpan span=d2-d1;

      
        	
        	 label1.Text=first+" to "+last+" \n  is days="+  span.TotalDays;
		        
            */
        	 
        	//  label1.Text=label1.Text+"\n"+"picturebox size is:";
        	 
        	// label2.Text=
		        
		   /*     
		        DateTime d1=DateTime.MinValue;
DateTime d2=DateTime.MaxValue;
TimeSpan span=d2-d1;
Console.WriteLine
         ( "There're {0} days between {1} and {2}" , span.TotalDays, d1.ToString(), d2.ToString() );
		        */
			
		       
		} //end function init_data()
		
		
		void Label2Click(object sender, EventArgs e)
		{
			
		}
		
		void Label3Click(object sender, EventArgs e)
		{
			
		}
		
		void TrackBar1ValueChanged(object sender, EventArgs e)
		{  
			if (trackBar1.Value > 1 && trackBar1.Value < 9){
				
			ovf.Opacity=trackBar1.Value*0.1;
			}
		}
		
		void TrackBar1Scroll(object sender, EventArgs e)
		{
			
		}
	}
}
