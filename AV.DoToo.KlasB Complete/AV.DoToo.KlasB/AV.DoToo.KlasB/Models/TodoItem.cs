using System;
using SQLite;

namespace AV.DoToo.KlasB.Models
{
    public class TodoItem
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        public string Title { get; set; }
        public bool Completed { get; set; }
        public DateTime Due { get; set; }
    }
}
