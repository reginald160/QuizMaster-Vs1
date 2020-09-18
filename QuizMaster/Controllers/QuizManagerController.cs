using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizMaster.Data;
using QuizMaster.Models;
using QuizMaster.Services;
using QuizMaster.ViewModels;

namespace QuizMaster.Controllers
{
    public class QuizManagerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        public QuizManagerController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreatSubject()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatSubject(Subject model)
        {
            _unitOfWork.AddSubject(model);
            await _unitOfWork.Save();
            return View();
        }
        public IActionResult CreatQuestion()
        {
          ViewBag.Subject =  _unitOfWork.GetSubjects();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatQuestion(Question model)
        {
            _unitOfWork.AddQuestion(model);
            await _unitOfWork.Save();
            return View();
        }
        public IActionResult CreatExam()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatExam(Examination model)
        {
            _unitOfWork.AddExam(model);
            await _unitOfWork.Save();
            return View();
        }
        [HttpGet]
        public IActionResult TakeExam()
        {
         
            ViewBag.Question = _context.Questions/*.Where(x => x.Id == 1)*/.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult TakeExam(Examination model)
        {
            if (ModelState.IsValid)
            {
                _context.Examinations.Add(model);
                _context.SaveChangesAsync();
                return View("CreatQuestion");
            }
            return NotFound();
           
        }




public IActionResult CalculateScores()
        {
            _context.Examiner.Include(x=> x.Exam).ThenInclude(x=> x.Questions).ToList();
            return View();
        }

    }
}
