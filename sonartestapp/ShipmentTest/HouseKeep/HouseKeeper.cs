﻿using Delivery.DESADVAdaptorsParallelRun.IntgTest.constants;

namespace lsp_delivery_tricepsadaptor_parallelrun.HouseKeep
{
    public class HouseKeeper:IHouseKeeper
    {

        public HouseKeeper() { 
        
        }

        public void DeleteFiles() {

            if (Directory.Exists(ApplicationConstants.LOCAL_EXPECTED_FILE_PATH))
            {
                Directory.Delete(ApplicationConstants.LOCAL_EXPECTED_FILE_PATH, true);
                Directory.CreateDirectory(ApplicationConstants.LOCAL_EXPECTED_FILE_PATH);
            }
            if (Directory.Exists(ApplicationConstants.LOCAL_ACTUAL_FILE_PATH))
            {
                Directory.Delete(ApplicationConstants.LOCAL_ACTUAL_FILE_PATH, true);
                Directory.CreateDirectory(ApplicationConstants.LOCAL_ACTUAL_FILE_PATH);
            }
        }
    }
}
