using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;
using DAC;
using System.Data;

namespace Service
{
    public class FactoryService
    {
        public List<FactoryVO> GetFactory()
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.GetFactory();
        }

        public bool AddFactory(FactoryVO vo)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.AddFactory(vo);
        }

        public bool UpdateFactory(FactoryVO vo)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.UpdateFactory(vo);
        }

        public bool DeleteFactory(int fid)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.DeleteFactory(fid);
        }


        public List<WareHouseVO> GetWarehouse()
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.GetWarehouse();
        }

        public bool UpdateWarehouse(FactoryVO fvo)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.UpdateWarehouse(fvo);
        }

        public bool AddWarehouse(FactoryVO fvo)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.AddWarehouse(fvo);
        }

        public bool DeleteWareHouse(int fid)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.DeleteWareHouse(fid);
        }

        public bool ExcelImportFactory(List<FactoryVO> temp)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.ExcelImportFactory(temp);
        }

        public bool ExcelImportWareHouse(List<FactoryVO> temp)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.ExcelImportWareHouse(temp);
        }
    }
}
