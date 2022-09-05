﻿using CustomerLibrary.Entities;
using System.Collections.Generic;

namespace CustomerLibrary.Interfaces
{
    public interface INoteService
    {
        Note GetNote(int id);
        Note Create(Note note);
        void Update(Note note);
        void Delete(int id);
        IReadOnlyCollection<Note> GetNotes(int id);
    }
}
