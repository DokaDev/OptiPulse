#include "pch.h"
#include "ExportLibs.h"

#include <iostream>
#include <vector>
#include <Psapi.h>

using namespace std;

extern "C" __declspec(dllexport) bool SetTokenPrivileges(const wstring & privilege) {
	HANDLE hToken;
	if (!OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, &hToken)) {
		cerr << "OpenProcessToken failed: " << GetLastError() << endl;
		return false;
	}

	TOKEN_PRIVILEGES tkp = {};
	if (!LookupPrivilegeValue(nullptr, privilege.c_str(), &tkp.Privileges[0].Luid)) {
		cerr << "LookupPrivilegeValue failed: " << GetLastError() << endl;
		CloseHandle(hToken);
		return false;
	}

	tkp.PrivilegeCount = 1;
	tkp.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED;
	if (!AdjustTokenPrivileges(hToken, FALSE, &tkp, sizeof(tkp), nullptr, nullptr)) {
		cerr << "AdjustTokenPrivileges failed: " << GetLastError() << endl;
		CloseHandle(hToken);
		return false;
	}

	CloseHandle(hToken);
	return true;
}

extern "C" __declspec(dllexport) bool SetAllPrivileges() {
	return true;
}