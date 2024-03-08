#pragma once
#ifndef MEMORY_MANAGER_EXPORT_LIBS_H
#define MEMORY_MANAGER_EXPORT_LIBS_H

#include "pch.h"
#include <vector>
#include <iostream>

extern "C" __declspec(dllexport) DWORDLONG getTotalSystemMemory();
extern "C" __declspec(dllexport) DWORDLONG getCurrentUsedMemory();
extern "C" __declspec(dllexport) double getMemoryUsagePercentage();
extern "C" __declspec(dllexport) bool SetTokenPrivileges(const wstring & privilege);
extern "C" __declspec(dllexport) bool SetAllPrivileges();

#endif