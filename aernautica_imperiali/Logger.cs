using System;

namespace aernautica_imperiali {
    public class Logger {
        private static Logger _instance = new Logger();
        public static bool LOG_TO_CONSOLE = true;

        private Logger() {
        }

        public static Logger GetInstance() {
            return _instance;
        }

        public void Info(string message) {
            if (LOG_TO_CONSOLE) {
                Console.WriteLine(message);
            }
        }
    }
}