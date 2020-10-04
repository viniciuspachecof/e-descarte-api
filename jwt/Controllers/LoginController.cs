using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using e_descarte_api.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using e_descarte_api.jwt.Services;


namespace e_descarte_api.jwt.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        
    }
}