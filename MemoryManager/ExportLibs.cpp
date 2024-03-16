#include "pch.h"
#include <iostream>

extern "C" __declspec(dllexport) DWORDLONG getTotalSystemMemory() {
	MEMORYSTATUSEX status;
	status.dwLength = sizeof(status);
	GlobalMemoryStatusEx(&status);
	return status.ullTotalPhys;
}

extern "C" __declspec(dllexport) DWORDLONG getCurrentUsedMemory() {
	MEMORYSTATUSEX status;
	status.dwLength = sizeof(status);
	GlobalMemoryStatusEx(&status);
	return status.ullTotalPhys - status.ullAvailPhys;
}

extern "C" __declspec(dllexport) double getMemoryUsagePercentage() {
	DWORD totalMemory = getTotalSystemMemory();
	DWORD usedMemory = getCurrentUsedMemory();
	if (totalMemory == 0) return 0;

	return static_cast<double>(usedMemory) / totalMemory * 100.0;
}