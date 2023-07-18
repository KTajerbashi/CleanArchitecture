﻿global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Mvc;
using Application.Library.Interfaces;
using Application.Library.Interfaces.Patterns;
using Application.Library.Service;
using Application.Library.Service.Products;
using Common.Library;
using Domain.Library.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Persistance.Library.DbContexts;