global using AutoMapper;
global using Entities.Constants;
global using Entities.Extensions;
global using CoreService;
global using Portal.ActionFilters;
global using Portal.Extensions;
global using Portal.Middlewares;
global using Portal.Resources;
global using Portal.Utility;
global using Entities;
global using Entities.AuthenticationModels;
global using Entities.CoreServicesModels.DashboardAdministrationModels;
global using Entities.DBModels.UserModels;
global using Entities.ResponseFeatures;
global using Entities.ServicesModels;
global using Microsoft.AspNetCore.Localization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Localization;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Newtonsoft.Json.Converters;
global using Repository;
global using Services;
global using System.Globalization;
global using System.IdentityModel.Tokens.Jwt;
global using System.Linq.Dynamic.Core;
global using System.Reflection;
global using System.Security.Claims;
global using System.Text;
global using TenantConfiguration;
global using static Entities.EnumData.DBModelsEnum;
global using static TenantConfiguration.TenantData;
global using Portal.Controllers;
global using System.ComponentModel;
global using System.ComponentModel.DataAnnotations;









