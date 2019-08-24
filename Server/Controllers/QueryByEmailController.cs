﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/Pessoa/query/email")]
    [ApiController]
    public class QueryByEmailController : ControllerBase
    {
        private readonly Context _context;

        public QueryByEmailController(Context context)
        {
            _context = context;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoasByName(string search)
        {
            if(search == null)
            {
                return BadRequest();
            }
            List<Pessoa> pessoas = await _context.Pessoas.ToListAsync();

            List<Pessoa> filtered = new List<Pessoa>();

            foreach(Pessoa p in pessoas)
            {
                if(p.Email.Contains(search))
                {
                    filtered.Add(p);
                }
            }

            return filtered;
        }
    }
}
