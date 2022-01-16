# generated from ament_cmake_export_assemblies/cmake/template/ament_cmake_export_assemblies.cmake.in

set(_exported_assemblies_dll "${girbal_msgs_DIR}/../../../lib/girbal_msgs/dotnet/girbal_msgs_assemblies.dll")

# append absolute assemblies to girbal_msgs_ASSEMBLIES_DLL
# warn about not existing paths
if(NOT "${_exported_assemblies_dll} " STREQUAL " ")
  find_package(ament_cmake_core QUIET REQUIRED)
  foreach(_exported_assembly_dll ${_exported_assemblies_dll})
    if(NOT EXISTS "${_exported_assembly_dll}")
      message(WARNING "Package 'girbal_msgs' exports the DLL assembly '${_exported_assembly_dll}' which doesn't exist")
    endif()
    normalize_path(_exported_assembly_dll "${_exported_assembly_dll}")
    list(APPEND girbal_msgs_ASSEMBLIES_DLL "${_exported_assembly_dll}")
  endforeach()
endif()

set(_exported_assemblies_nuget "")

# append absolute assemblies to girbal_msgs_ASSEMBLIES_NUGET
# warn about not existing paths
if(NOT "${_exported_assemblies_nuget} " STREQUAL " ")
  find_package(ament_cmake_core QUIET REQUIRED)
  foreach(_exported_assembly_nuget ${_exported_assemblies_nuget})
    if(NOT EXISTS "${_exported_assembly_nuget}")
      message(WARNING "Package 'girbal_msgs' exports the NuGet assembly '${_exported_assembly_nuget}' which doesn't exist")
    endif()
    normalize_path(_exported_assembly_nuget "${_exported_assembly_nuget}")
    list(APPEND girbal_msgs_ASSEMBLIES_NUGET "${_exported_assembly_nuget}")
  endforeach()
endif()
