﻿namespace MyPortfolio.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCurrentPosition { get; set; }
        public string Description { get; set; }
        public string CompanyLogoUrl { get; set; }

        // Navigation property
        public ICollection<ExperienceHighlight> Highlights { get; set; }
    }
}
