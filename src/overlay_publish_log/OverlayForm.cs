/*
 * Created by SharpDevelop.
 * User: toby
 * Date: 3/26/2013
 * Time: 2:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace overlay_publish_log
{
	/// <summary>
	/// Description of OverlayForm.
	/// </summary>
	public partial class OverlayForm : Form
	{
		public string sitepath;
		
	   //globals
	   
	   int total_days_span=0;
	   int algo_total_days_span=0;
        List<string> labels= new List<string>();
		List<string> datestrs= new List<string>();
		List<string> descriptions= new List<string>();
		
		List<string> algo_labels= new List<string>();
		List<string> algo_datestrs= new List<string>();
		
		List<string> site_names= new List<string>();
		List<string> site_project_paths= new List<string>();
		 
		
		
		public OverlayForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			
			
		}
		
		void PictureBox1SizeChanged(object sender, EventArgs e)
		{
			
			label1.Visible=false;
			
			int   mark_apart_pixels=5;
			int   small_mark_width=1;
			int   mark_width=2;
			int y_step=15;
			int y_stepdown=10;
			
			
			int y_step2=20;
			int y_stepdown2=50;
			
			 Font f1=new Font("Verdana", 8);
			
			if (total_days_span<5){
				total_days_span=5;
				
			}
			
			 int right_margin_offset=100;
			 
			// int cushioned_width= pictureBox1.Width-40;
			 
			try{
			 	mark_apart_pixels=Convert.ToInt32((pictureBox1.Width-right_margin_offset)/total_days_span);
			}catch(Exception zeroexception){
				
				
			}
			
			
			
		  label1.Text="Width="+pictureBox1.Width.ToString()+"  totaldays="+total_days_span+"  apart="+mark_apart_pixels; 	
		  
		  
		  
		  
		  //draw the bitmap
		  Bitmap Bmp = null;
		  
		  
		  
		  try{
		  	Bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
		  }catch(Exception bex){
		  	
		  }
		  	
		  
		        string first=datestrs[0];
		       
		       
		        
		       // string dateString = "5/1/2008 8:30:52 AM";
		       string[] parts =first.Split('-');
		       string dateString1 =null;
		       
		       //need a way to check for quoates in the data and strip that out if existing
		       //where does dateString get populated?
		       
		       
		       try{
		       dateString1 = parts[1]+"/"+parts[2]+"/"+parts[0]+" 8:00:00 AM";
		         
		       }catch(Exception ex234){
		       	MessageBox.Show("problem with first date range. msg is " + ex234.Message);
		       }
		         
		      
		       	//MessageBox.Show("dateString1 is " + dateString1);
		       	
		       
		       DateTime prev_d1=prev_d1 = DateTime.Parse(dateString1, System.Globalization.CultureInfo.InvariantCulture);
		       
		          int day_mark_height= 30;
		  	       int day_mark_y=pictureBox1.Height-day_mark_height;
		
		     // draw the day marks
		     
		        try{
		        using (Graphics gfx = Graphics.FromImage(Bmp)){
		  		using (SolidBrush brush = new SolidBrush(Color.Black))
				{
		  	         
		  	      
		  	    
		  	       
				   int current_mark=0;
				  	for (int i = 0; i < total_days_span; i++){
				  		
			           current_mark = current_mark+mark_apart_pixels;
		               
			           gfx.FillRectangle(brush, current_mark,  day_mark_y, small_mark_width,  day_mark_height);
			           
			         //  if ((i % 10)==0){
			          // 	gfx.DrawString("mark="+current_mark.ToString(),f1,brush,current_mark,y_stepdown);
			           	  
			         //  } //end if
			           
				  	} //end foreach
				   
				} 	//end using
		  		
		  		
				using (SolidBrush brush = new SolidBrush(Color.Red))
				{
		  	         
		  	       //the dates render
		  	       
		  	          int current_mark=0;
		  	         
				  	//foreach (datestrs as string datestr){
				  	
				 
				  	int event_count=0;
				  	for (int i = 0; i < datestrs.Count; i++){
				  		
				  		string[] dateparts =datestrs[i].Split('-');
			       string dateString = dateparts[1]+"/"+dateparts[2]+"/"+dateparts[0]+" 8:00:01 AM";
			        DateTime d1 = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
			          
		                	
		              
		    
		             TimeSpan span=d1 - prev_d1;
		             
		             //need to multiply days * pixels/day to get units in pixels
		             int next_jump= (Convert.ToInt32(span.TotalDays) * mark_apart_pixels);
             
		                current_mark = current_mark+next_jump;
		                
				  		gfx.FillRectangle(brush,current_mark , 0, mark_width, pictureBox1.Height);
				  		
				  		gfx.DrawString(labels[i],f1,brush,current_mark,y_stepdown);
				  		
				  		
				  			
				  		
				  		
				  		y_stepdown =y_stepdown+y_step;
				  		
				  		
				  		
				  		 	//draw the dates
				  		if (event_count==0){
				  	         gfx.DrawString(datestrs[i],f1,brush,current_mark,day_mark_y-20);
			  		 	}else{
			  		 		string[] tempparts=datestrs[i].Split('-');
			  		 		string shortdate=tempparts[1]+'/'+tempparts[2];
			  		 		gfx.DrawString(shortdate,f1,brush,current_mark,day_mark_y-20);
			  		 	}
				  		 	
				  		// 	if (event_count==(datestrs.Count-1)){
				 // 	gfx.DrawString(datestrs[i],f1,brush,current_mark,day_mark_y-20);
				  	// MessageBox.Show("at end -event_count="+ event_count+" datestrs[i]="+datestrs[i]+" current_mark="+current_mark);
				 // 	}	
				  		
				  	event_count++;
				  		//reset
				  		 prev_d1=d1;
				  		
				  	} //end foreach
				  
				} 	//end using
				
				
				
				
				//resets
				        
		       // string dateString = "5/1/2008 8:30:52 AM";
		       parts =first.Split('-');
		      dateString1 = parts[1]+"/"+parts[2]+"/"+parts[0]+" 8:00:00 AM";
		       prev_d1 = DateTime.Parse(dateString1, System.Globalization.CultureInfo.InvariantCulture);
		       
				
				
				//now for google algo
				using (SolidBrush brush = new SolidBrush(Color.Purple))
				{
		  	         
		  	       //the dates render
		  	       
		  	          int current_mark=0;
		  	         
				  	//foreach (datestrs as string datestr){
				  	
				 
				  	int event_count=0;
				  	for (int i = 0; i < algo_datestrs.Count; i++){
				  		
				  		string[] dateparts =algo_datestrs[i].Split('-');
			       string dateString = dateparts[1]+"/"+dateparts[2]+"/"+dateparts[0]+" 8:00:01 AM";
			        DateTime d1 = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
			          
		                	
		              
		    
		             TimeSpan span=d1 - prev_d1;
		             
		             //need to multiply days * pixels/day to get units in pixels
		             int next_jump= (Convert.ToInt32(span.TotalDays) * mark_apart_pixels);
             
		                current_mark = current_mark+next_jump;
		                
				  		gfx.FillRectangle(brush,current_mark , 0, mark_width, pictureBox1.Height);
				  		
				  		gfx.DrawString(algo_labels[i],f1,brush,current_mark,y_stepdown2);
				  		
				  		
				  			
				  		
				  		
				  		y_stepdown2 =y_stepdown2+y_step2;
				  		
				  		
				  		
				  		
				  		 	//draw the dates
				  		if (event_count==0){
				  	         gfx.DrawString(algo_datestrs[i],f1,brush,current_mark,day_mark_y-20);
			  		 	}else{
			  		 		string[] tempparts=algo_datestrs[i].Split('-');
			  		 		string shortdate=tempparts[1]+'/'+tempparts[2];
			  		 		gfx.DrawString(shortdate,f1,brush,current_mark,day_mark_y-20);
			  		 	}
				  		
				  		 	//draw the endpoitn dates
				  		// 	if (event_count==0){
				  //	gfx.DrawString(datestrs[i],f1,brush,current_mark,day_mark_y-20);
				  	//	 	}
				  		 	
				  	//	 	if (event_count==(datestrs.Count-1)){
				  	//gfx.DrawString(datestrs[i],f1,brush,current_mark,day_mark_y-20);
				  	// MessageBox.Show("at end -event_count="+ event_count+" datestrs[i]="+datestrs[i]+" current_mark="+current_mark);
				//  	}	
				  		
				  	event_count++;
				  		//reset
				  		 prev_d1=d1;
				  		
				  	} //end foreach
				  
				} 	//end using
				
				
		  }//end outer useing
		  
		  pictureBox1.Image=Bmp;
		  
		        }catch(Exception catcall){
		        	
		        	
		        }
		} //end function
		
		void Label1SizeChanged(object sender, EventArgs e)
		{
			
		}
		
		
			public void init_data(DateTime startrange, DateTime endrange){
			 
			
		 //   MessageBox.Show("sitepath="+sitepath);
		    
		    
			string best_path=sitepath;
			//string[] parts =sitepath.Split('\\');
			//string offline_path="localdata\\" + parts[parts.Length-1];
          //  string use_path=offline_path;
			
          string use_path=best_path;
            
           //init the given range data
           labels.Add("start");
           
           string datestr=startrange.Year+"-"+startrange.Month+"-"+startrange.Day;
	     datestrs.Add(datestr);
	     descriptions.Add(datestr);
          
            
         /*   if (File.Exists(best_path)){
            	
            	use_path=best_path;
            	File.Delete(offline_path);
            	File.Copy(best_path,offline_path);
            }
			*/
			
          //  MessageBox.Show("use_path="+use_path);
			
			// start loading site data for whichever site is sselected
			
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
		            	
		            	
		            	
		            	
		            	
		            	while ( line != null ){  //foreach line of spreadsheet
		            		
		            		line=sr.ReadLine();
		            		
		            		line=line.Replace("\"","");
		            		
		            		if (count!=0){ 
		            			// only do stuff after first row (headers)
		            			string[] dataset= line.Split(';');
		            			
		            			int runaway_cap=0;
		            			while (dataset.Length !=4 && runaway_cap < 1000){ //loop fo rmultiline descr
		            				
		            			 	String another_line=sr.ReadLine();
		            			 	
		            			 	dataset = (line+another_line).Split(';');
		            			 	
		            			 	 runaway_cap++;
		            			 	
		            			} 
		            			  //continue on
		            			//MessageBox.Show("feilds="+dataset.Length.ToString());
		            			
		            			
		            			
		            			//dataset is uniform and valid here
		            			String label = dataset[0];
		            			 datestr = dataset[1];
		            			String description = dataset[3];
		            			
		            			//checking if we almost have a date signature for 201*-**-**
		            			if (datestr.Contains("201")  ){
		            				
		            				
		            				//now check further if we are in the date range before adding this item
		            				DateTime comparedate=DateTime.Parse(datestr);
		            			
		            			
		            				if (comparedate.CompareTo(startrange) > 0){
		            					if (comparedate.CompareTo(endrange) < 0){
		            						 labels.Add(label);
		            		                 datestrs.Add(datestr);
		            		                 descriptions.Add(datestr);
		            					}
		            				}
		            				
		            				
		            		    
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
		          // MessageBox.Show(iex.Message);
		        }
		        
		       
		        
		         //finalize the given range data
           labels.Add("end");
           
          datestr=endrange.Year+"-"+endrange.Month+"-"+endrange.Day;
	     datestrs.Add(datestr);
	     descriptions.Add(datestr);
          
		          
		        string last="-";
		        string first="-";
		      
		        try{
		        
			         last=datestrs[datestrs.Count-1];
			         first=datestrs[0];
		        }catch(Exception datex){
		        	MessageBox.Show(datex.Message);
		        }
		       
		        
		       // string dateString = "5/1/2008 8:30:52 AM";
		       string[] parts =first.Split('-');
		       string dateString1 = parts[1]+"/"+parts[2]+"/"+parts[0]+" 8:00:01 AM";
		        DateTime d1 = DateTime.Parse(dateString1, System.Globalization.CultureInfo.InvariantCulture);
		       
		          
		          parts = last.Split('-');
		       string dateString2 = parts[1]+"/"+parts[2]+"/"+parts[0]+" 8:00:01 AM";
		       
             DateTime d2= DateTime.Parse(dateString2, System.Globalization.CultureInfo.InvariantCulture); 
		    
             TimeSpan span=d2-d1;

             total_days_span= Convert.ToInt32(span.TotalDays);
        	
             
             
             /// below hre is for new algo code
             
             try
		        {
		            using (StreamReader sr = new StreamReader("localdata\\algo_log.csv"))
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
		            			 datestr = dataset[1];
		            			String description = dataset[3];
		            			
		            			//checking if we almost have a date signature for 201*-**-**
		            			if (datestr.Contains("201")  ){
		            			
		            		     algo_labels.Add(label);
		            		     algo_datestrs.Add(datestr);
		            		     //descriptions.Add(datestr);
		            			}
		            			
		            			//MessageBox.Show("label="+label+ " date="+datestr);
		            			
		            		}
		            		
		            		count++;
		            	} //end while
		            	
		                //String bigstr = sr.ReadToEnd();
		               // Console.WriteLine(line);
		               //MessageBox.Show(bigstr);
		            }
		        }
		        catch (Exception iex)
		        {
		           // Console.WriteLine("The file could not be read:");
		           // Console.WriteLine(e.Message);
		        // MessageBox.Show(iex.Message);
		        }
		        
		        
		        last=datestrs[datestrs.Count-1];
		        first=datestrs[0];
		       
		       
		        
		       // string dateString = "5/1/2008 8:30:52 AM";
		        parts =first.Split('-');
		        dateString1 = parts[1]+"/"+parts[2]+"/"+parts[0]+" 8:00:01 AM";
		         d1 = DateTime.Parse(dateString1, System.Globalization.CultureInfo.InvariantCulture);
		       
		          
		          parts = last.Split('-');
		        dateString2 = parts[1]+"/"+parts[2]+"/"+parts[0]+" 8:00:01 AM";
		       
              d2= DateTime.Parse(dateString2, System.Globalization.CultureInfo.InvariantCulture); 
		    
             TimeSpan span2=d2-d1;

             algo_total_days_span= Convert.ToInt32(span2.TotalDays);
             
             
            // MessageBox.Show("datecount="+ datestrs.Count);
             
        	// label1.Text=first+" to "+last+" \n  is days="+  span.TotalDays;
		        
            
        	 
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
	}
}
