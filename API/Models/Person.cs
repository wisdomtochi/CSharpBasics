﻿namespace API.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Rootobject
    {
        public Item[] items { get; set; }
        public bool has_more { get; set; }
        public int quota_max { get; set; }
        public int quota_remaining { get; set; }
    }

    public class Item
    {
        public Owner owner { get; set; }
        public bool is_accepted { get; set; }
        public int score { get; set; }
        public int last_activity_date { get; set; }
        public int creation_date { get; set; }
        public int answer_id { get; set; }
        public int question_id { get; set; }
        public string content_license { get; set; }
        public int last_edit_date { get; set; }
    }

    public class Owner
    {
        public int reputation { get; set; }
        public int user_id { get; set; }
        public string user_type { get; set; }
        public string profile_image { get; set; }
        public string display_name { get; set; }
        public string link { get; set; }
        public int accept_rate { get; set; }
    }
}
