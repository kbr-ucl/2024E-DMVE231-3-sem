using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorDemo.Database;
using RazorDemo.WeatherService;

namespace RazorDemo.Pages.Weather
{
    public class IndexModel : PageModel
    {

        
        public IndexModel()
        {

        }

        public IList<WeatherForecastDto> WeatherForecastDto { get;set; } = default!;

        public async Task OnGetAsync()
        {

            var baseAddress = new Uri("https://localhost:7019/");
            var client = new HttpClient { BaseAddress = baseAddress };
            WeatherForecastDto = await client.GetFromJsonAsync<List<WeatherForecastDto>>("weatherforecast");
        }
    }
}
