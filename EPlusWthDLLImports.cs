namespace EPusWth 
{
	// This class just houses the imports of functions from the enternal DLL.
	internal static class EPlusWthDLLImports
	{
		// This code is based on docuementation located at:
		//   https://bigladdersoftware.com/epx/docs/8-2/auxiliary-programs/advanced-use-accessing-weather-conversion.html
		//
		// and also covered in the EnergyPlus™ Version x.x.x Documentation Auxiliary Programs (PDF).
		//
		// DLL imports below created initially using the link below based on the DB imports in the Weather Converter documentation.
		// http://www.carlosag.net/tools/codetranslator/
		// Then somewhat modified to make them actually work.

		// From documentation:
		//
		// 2.14.3.1 SetupPWInternalDataPath
		// This call designates the “path” to the [various required internal data files]. This is the location where the ProcessWeather call

		// will expect to find the files. Having this incorrectly specified is not fatal, but will probably cause confusion.        
		[DllImport("EPlusWth.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void SetupPWInternalDataPath(string path, int pathLen);

		// From documentation:
		//
		// 2.14.3.2 SetFixOutOfRangeData
		//
		//  ...there is an option to “fix” out of range data or not. By default, this is turned off(does not fix data). 
		// ...a character convention (“yes” for fixing; “no” for not fixing) is used. Case of the actual string is ignored.     
		[DllImport("EPlusWth.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void SetFixOutOfRangeData(string fixOutOfRangeData, int fixOutOfRangeDataLen);


		// From documentation:
		//
		// 2.4.1.2 Select Delta DB Trigger
		//
		// Depending on the quality control and accuracy of the weather data collection, time period (usually
		// hour to hour) changes in some data values may make the data suspect for that time period. This
		// selection will allow the user some control over the actual value reporting. 
		// Note that this data is not “fixed”, merely reported by the program in the audit output file.
		// ...  
		// Changes >= [the trigger value] will be reported [in the audit file].
		//
		// Parameters:
		// Trigger Limit    Result
		// 0                use only calculated trigger
		// 1                use 5°C
		// 2                use 10°C
		// 3                use 15°C
		//
		// Ignore Calc Trigger  Result
		// 0                    Uses Calculated Trigger
		// 1                    Ignores calculated trigger
		//
		// 2.14.3.3 SetDefaultChgLimit
		//
		// You can also choose to ignore the calculated trigger entirely. If you do not “ignore” the calculated
		// trigger, then the trigger is the minimum of the calculated and your trigger limit selection.
		[DllImport("EPlusWth.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void SetDefaultChgLimit(string triggerLimit, int triggerLimitLen, string ignoreCalcTrigger, int ignoreCalcTriggerLen);


		// From documentation:
		//
		// 2.14.3.4 ProcessWeather
		// The “meat” of the processing is done by this routine. It gets passed the input file name (source
		// data), the input file type, output file name, and output file type. As an output it can provide a
		// notice that the processing was successful or not.
		//
		// 2.5.3.3 Field: OutputURL
		// When a list of files is being processed, one of the outputs that results from 
		// the processing is a KML (Keyhole Markup Language) file that can be used with Google Earth to pinpoint 
		// the locations of the weather site. This field can be used to set this URL for later output. The list file 
		// format also includes a URL as its third (optional) parameter. 
		// If included, this input would overwrite other URL designations.
		[DllImport("EPlusWth.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void ProcessWeather(
			string inputFileDataType, int inputFileDataTypeLen,
			string outputFileDataType, int outputFileDataTypeLen,
			string inputFileName, int inputFileNameLen,
			string outputFileName, int outputFileNameLen,
			[Out] out bool errorFlag,
			string strOutFileURL = "", int OutFileURLlen = 0);
	} 
}