using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;
namespace Service
{
    class MenuService
    {
        public List<MenuVO> GetMenus()
        {
            MenuDAC dac = new MenuDAC();
            return dac.GetMenus();
        }
    }
}
