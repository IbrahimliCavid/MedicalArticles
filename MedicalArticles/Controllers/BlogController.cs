using Business.Abstract;
using Entities.Dtos;
using FluentValidation.Results;
using MedicalArticles.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICommentService _commentService;

        public BlogController(IBlogService blogService, ICommentService commentService)
        {
            _blogService = blogService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
            var datas = _blogService.GetAllByLangauge(currentCulture).Data;
            return View(datas);
        }

        public IActionResult Details(int id) {

            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
            var datas = _blogService.GetAllByLangauge(currentCulture).Data;
            var data = datas.Find(d => d.Id == id);
            return View(data);
        }

        [HttpPost]
        public IActionResult AddComment(CommentCreateDto dto)
        {


            var result = _commentService.Add(dto, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                ModelState.Clear();
                foreach (var error in errors)
                {
                    ModelState.AddModelError($"{error.PropertyName}", error.ErrorMessage);
                }
                return View(dto);
            }

            return RedirectToAction("Details");
        }
    }
}
