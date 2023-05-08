﻿using MagicVilla_web.Models;
using MagicVilla_web.Services.IServices;
using MagicVilla_Web.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_web.Controllers
{
	public class AuthController : Controller
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpGet]
		public IActionResult Login()
		{
			LoginRequestDTO obj = new LoginRequestDTO();
			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginRequestDTO obj)
		{
			return View(obj);
		}


		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterationRequestDTO obj)
		{
			APIResponse result = await _authService.RegisterAsync<APIResponse>(obj);
			if (result != null && result.IsSuccess) 
			{
				return RedirectToAction("Login");
			}
			return View(obj);
		}

		public async Task<IActionResult> Logout()
		{
			return View();
		}

		public IActionResult AccessDenied() 
		{
			return View();
		}

	}
}
