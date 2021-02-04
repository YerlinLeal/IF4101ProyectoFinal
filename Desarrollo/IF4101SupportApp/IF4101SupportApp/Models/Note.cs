using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IF4101SupportApp.Models
{
    public class Note
    {
        public int NoteId;
        public string Description;

        public Note(int noteId, string description)
        {
            NoteId = noteId;
            Description = description;
        }

        public Note()
        {
        }
    }
}
