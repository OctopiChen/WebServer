using Microsoft.AspNetCore.Mvc;
using WebServer.Services;

namespace WebServer.Components
{
    [ViewComponent(Name = "Language")]//在View要用到時使用的名稱
    //MyLang-> 在View中呼叫名稱:my-lang(小寫+底線)
    public class LanguageComponent : ViewComponent
    {
        private readonly SiteService _siteService;

        public LanguageComponent(SiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            await Task.Yield();
            return View("Default", _siteService.GetCurrentCulture());
        }
    }
}