using System.Linq;
using System.Net;
using BriconApi.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;

namespace BriconApi.MVC
{
    public static class ErrorsHandlerMiddlewareExtensions
	{
		private static void ConfigureExceptionHandler(IApplicationBuilder app)
		{
			app.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{
					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

					if (contextFeature != null)
					{
						var exception = contextFeature.Error;

						await JsonApiResult.Error($"ОШИБКА: {exception?.InnerException?.Message ?? exception?.Message}", 500).ExecuteResultAsync(context);
					}
					else
					{
						await JsonApiResult.Error("Internal server error.", 500).ExecuteResultAsync(context);
					}
				});
			});
		}

		private static void ConfigureStatusCodePagesHandler(IApplicationBuilder app)
		{
			app.UseStatusCodePages(errApp =>
			{
				errApp.Run(async context =>
				{
					await JsonApiResult.Error($"Error: {(HttpStatusCode)context.Response.StatusCode}", context.Response.StatusCode)
						.ExecuteResultAsync(context);
				});
			});
		}

		public static void ConfigureErrorsHandler(this IApplicationBuilder app)
		{
			ConfigureExceptionHandler(app);
			ConfigureStatusCodePagesHandler(app);
		}

		public static IMvcBuilder AddApiErrorsHandler(this IMvcBuilder services)
		{
			services.ConfigureApiBehaviorOptions(o =>
			{
				o.InvalidModelStateResponseFactory = actionContext =>
					ErrorInvalidInput(actionContext.ModelState);
			});

			return services;
		}

		static string[] GetErrorList(ModelStateDictionary model)
			=> model.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage.TrimEnd('.')).ToArray();

		static JsonApiResult ErrorInvalidInput(ModelStateDictionary model)
		{
			return JsonApiResult.Error($@"Некорректное тело запроса. Ошибки: {string.Join(", ", GetErrorList(model))}", 415);
		}
	}
}