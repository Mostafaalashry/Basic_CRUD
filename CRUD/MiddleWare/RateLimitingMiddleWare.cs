using System;
namespace CRUD.MiddleWare
{
	public class RateLimitingMiddleWare
	{
        private readonly RequestDelegate _next;
		private static int _counter = 0  ;
        private static DateTime _lastRequestDate = DateTime.Now;

        public RateLimitingMiddleWare(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context) {
			_counter++;

			if (_lastRequestDate.Subtract(DateTime.Now).Seconds > 10)
			{
				_counter = 1;
				_lastRequestDate = DateTime.Now;
                await _next(context);


            }
            else
			{
				if (_counter > 5)
				{
					_lastRequestDate = DateTime.Now;
					await context.Response.WriteAsync("Rate limit exceded");
				}
				else
				{
					_lastRequestDate = DateTime.Now;
					await _next(context); 
				}

			}

		}
	}
}

