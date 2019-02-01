﻿using System;

namespace BirdWatcher.Web.Models
{
    public class Observation
    {
        public int? Id { get; set; }
        public string Bird { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
    }
}
