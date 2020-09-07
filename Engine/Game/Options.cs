using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Game
{
    public class Options
    {

        private static Options instance = new Options();
        //private static Properties cfg;

        private int width, height;

        private Options()
        {
            //cfg = new Properties();
            //try
            //{
            //    File fIn = new File("resources/config.xml");
            //    InputStream is = new FileInputStream(fIn);
            //    cfg.loadFromXML(is);
            //is.close();
            //}
            //catch (Exception e)
            //{
            //    setDefaultValues();
            //    store();
            //}
        }

        public static Options getInstance()
        {
            return instance;
        }

        //public static Properties getProperties()
        //{
        //    return cfg;
        //}

        //private static void setDefaultValues()
        //{
        //    cfg.setProperty("width", "800");
        //    cfg.setProperty("height", "600");
        //    cfg.setProperty("fps", "60");
        //    cfg.setProperty("vsync", "true");
        //}

        public static void store()
        {
            //try
            //{
            //    File fOut = new File("resources/config.xml");
            //    OutputStream os = new FileOutputStream(fOut);
            //    cfg.storeToXML(os, "Project Merlin configuration file.");
            //    os.close();
            //}
            //catch (Exception e)
            //{
            //    e.printStackTrace();
            //}
        }


    }
}
