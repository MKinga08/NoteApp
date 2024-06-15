using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NoteApp
{
    public class JSONNote
    {
        public List<Note> JsonNotes { get; set; }

        public JSONNote()
        { 
            JsonNotes = new List<Note>();
        }
        public void ReadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                JsonNotes = JsonSerializer.Deserialize<List<Note>>(json);
            }
            else
            {
                throw new FileNotFoundException("The specified file was not found.", filePath);
            }
        }
    }
}
