﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{
	//In this fictitious example these are the 'modes' in which training can occur,
	//but you may recognise them as something else related to the assignment
	public enum Mode { Conference, Journal, Other };

    /// <summary>
    /// A training session undertaken by an employee on a particular date.
    /// Created in task 1.2 of the Week 8 tutorial.
    /// </summary>
    public class Publication
    {
        public string Doi { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public int PublicationYear { get; set; }
        public OutputType Type { get; set; }
        public string CiteAs { get; set; }
        public DateTime Available { get; set; }
        //enum OutputType, +Conference, +Journal, +Other
        //+DOI: string
        //+Title: string
        //+Authors: string
        //+Year: Date
        //+Type: OutputType
        //+CiteAs: string
        //+Available: Date

        //+Age(): integer

        public int Freshness
        {
            //DateTime.Today returns today's date. As DateTime objects overload the
            //addition and subtraction operators we can use them to determine the
            //elapsed time between today's date and the Completed date. However, 
            //the result is not a number but a TimeSpan object, whose Days
            //property gives the number of whole days represented by the TimeSpan.
            get { return (DateTime.Today - Certified).Days; }
        }

        public override string ToString()
        {
            //This is a straightforward way of constructing the string using DateTime's
            //ToShortDateString method to remove the time component of the complted date
            return Title + " completed by " + Mode + " on " + Certified.ToShortDateString();
            
            //This alternative approach uses the Format method of string, with the
            //short date format requested via the :d in the format string
            //return string.Format("{0} completed by {1} on {2:d}", Title, Mode, Certified);
        }
    }
}

