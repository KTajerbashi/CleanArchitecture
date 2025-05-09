﻿global using CleanArchitecture.Core.Application.Library.Common.Models.Requests;
global using CleanArchitecture.Core.Application.Library.Providers;
global using CleanArchitecture.EndPoint.WebApi.Common.Controllers;
global using CleanArchitecture.EndPoint.WebApi.Common.Models;
global using CleanArchitecture.Infra.SqlServer.Library.Identity.Repositories;
global using CleanArchitecture.Infra.SqlServer.Library.Identity.Service;
global using FluentValidation;
global using Hangfire;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.Infrastructure;
global using Microsoft.IdentityModel.Tokens;
global using Serilog;
global using System.IdentityModel.Tokens.Jwt;
global using System.Text;
global using System.Text.Json;
