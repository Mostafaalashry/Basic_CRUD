using System;
using System.Diagnostics;

namespace CRUD.MiddleWare
{
	public class ProfilingMiddleWare
	{
        private readonly RequestDelegate _next;
        private readonly ILogger<ProfilingMiddleWare> _logger;

        public ProfilingMiddleWare(RequestDelegate next , ILogger<ProfilingMiddleWare>logger)
		{
			_next = next;
			_logger = logger;

		}

		public async Task Invoke(HttpContext context)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			await _next(context);
			stopwatch.Stop();
			_logger.LogInformation($"Requestt '{context.Request.Path} ' TOOK {stopwatch.ElapsedMilliseconds} msssssssssssssssssssssssssssss to execute");
			//
		}

	}
}

