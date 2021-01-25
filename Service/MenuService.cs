using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;
namespace Service
{
    public class MenuService
    {
        public List<MenuVO> GetMenus()
        {
            MenuDAC dac = new MenuDAC();
            return dac.GetMenus();
        }

        /// <summary>
        /// 대메뉴 등록
        /// </summary>
        /// <param name="menuName"></param>
        public bool AddLargeMenu(string menuName)
        {
            MenuDAC dac = new MenuDAC();
            return dac.AddLargeMenu(menuName);
        }

        public bool AddSmallMenu(string menuName, string parentName)
        {
            MenuDAC dac = new MenuDAC();
            return dac.AddSmallMenu(menuName, parentName);
        }

        public bool DeleteMenu(string menuName)
        {
            MenuDAC dac = new MenuDAC();
            return dac.DeleteMenu(menuName);
        }

        public bool LinkMenuToForm(string menuName, string formName)
        {
            MenuDAC dac = new MenuDAC();
            return dac.LinkMenuToForm(menuName, formName);
        }
    }
}
