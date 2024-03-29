﻿using AutoMapper;
using EF;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Notes;
using UoW;

namespace Services
{
    public class NoteService: INoteService
    {
        private AppDbContext context = new AppDbContext();
        UnitOfWork unitOfWork = new UnitOfWork();

        public List<NoteViewModel> GetAllNotes()
        {

            List<Note> notes = unitOfWork.Repository<Note>().GetAll().ToList();

            //List<Note> notes = context.Note.ToList();
            List<NoteViewModel> list = Mapper.Map<List<NoteViewModel>>(notes);
            return list;
        }

        public void Create(NoteViewModel noteViewModel)
        {
            Note note = Mapper.Map<Note>(noteViewModel);
            note.UpdateDate = DateTime.Now;
            note.InsertDate = DateTime.Now;
            context.Note.Add(note);
            context.SaveChanges();
        }
    }
}
