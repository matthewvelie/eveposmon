//#define DEBUG_SINGLETHREAD
//#define USE_LOCALHOST
// (If setting DEBUG_SINGLE THREAD, also set it in CharacterMonitor.cs)
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.Reflection;

namespace EVEMon.Common
{
    public class EveSession
    {
        /// <summary>
        /// Compute the "cached until" time for the user's machine from the currentTime and cachedUntil nodes 
        /// in a CCP API message.
        /// </summary>
        /// <param name="xdoc">The xml message after validating that there is actual content!</param>
        /// <returns>a DateTime object in UTC time for when the message can be retrieved again - adjusted to compensate for the user's clock</returns>
        public static DateTime GetCacheExpiryUTC(XmlDocument xdoc)
        {
            // Firstly, extract the currentTime form the message - in case things go wrong, assume currentTine is "now"
            DateTime CCPCurrent = DateTime.Now.ToUniversalTime();
            try
            {
                XmlNode currentTimeNode = xdoc.SelectSingleNode("/eveapi/currentTime");
                CCPCurrent = EveSession.ConvertCCPTimeStringToDateTime(currentTimeNode.InnerText);
            }
            catch (Exception)
            {
                // do  nothing - default to "now";
            }

            // Now suck out the cachedUntil time - assume 1 hour from now in case the parse fails
            DateTime cacheExpires = DateTime.Now + new TimeSpan(1, 0, 0);
            try
            {
                XmlNode cachedTimeNode = xdoc.SelectSingleNode("/eveapi/cachedUntil");
                cacheExpires = EveSession.ConvertCCPTimeStringToDateTime(cachedTimeNode.InnerText);
            }
            catch (Exception)
            {
                // do  nothing - default to "now";
            }


            // Work out teh cache period from the message and calculate the expiry time according to user's pc clock...
            return DateTime.Now.ToUniversalTime() + (cacheExpires - CCPCurrent);
        }

        /// <summary>
        /// Converts a CCP API date/time string to a UTC DateTime
        /// </summary>
        /// <param name="timeUTC"></param>
        /// <returns></returns>
        public static DateTime ConvertCCPTimeStringToDateTime(string timeUTC)
        {
            // timeUTC  = yyyy-mm-dd hh:mm:ss
            if (timeUTC == null || timeUTC == "")
                return DateTime.MinValue;
            DateTime dt = new DateTime(
                            Int32.Parse(timeUTC.Substring(0, 4)),
                            Int32.Parse(timeUTC.Substring(5, 2)),
                            Int32.Parse(timeUTC.Substring(8, 2)),
                            Int32.Parse(timeUTC.Substring(11, 2)),
                            Int32.Parse(timeUTC.Substring(14, 2)),
                            Int32.Parse(timeUTC.Substring(17, 2)),
                            0,
                            DateTimeKind.Utc);
            return dt;
        }
    }
}
