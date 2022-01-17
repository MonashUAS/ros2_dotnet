cmake_minimum_required(VERSION 3.5)

project(test_node C)

find_package(ament_cmake REQUIRED)
find_package(rcldotnet REQUIRED)

find_package(rcldotnet_common REQUIRED)

find_package(std_msgs REQUIRED)
find_package(rcldotnet REQUIRED)
find_package(girbal_msgs REQUIRED)

find_package(dotnet_cmake_module REQUIRED)

set(CSHARP_TARGET_FRAMEWORK "netcoreapp2.0")
find_package(DotNETExtra REQUIRED)

set(_assemblies_dep_dlls
    ${rcldotnet_common_ASSEMBLIES_DLL}
    ${rcldotnet_ASSEMBLIES_DLL}
    ${std_msgs_ASSEMBLIES_DLL}
    ${rcldotnet_ASSEMBLIES_DLL}
    ${girbal_msgs_ASSEMBLIES_DLL}
)

message("Included assemblies: ${_assemblies_dep_dlls}")

add_dotnet_executable(test_talker
  TestTalker.cs
  INCLUDE_DLLS
  ${_assemblies_dep_dlls}
)

add_dotnet_executable(test_listener
  TestListener.cs
  INCLUDE_DLLS
  ${_assemblies_dep_dlls}
)

install_dotnet(test_talker DESTINATION lib/${PROJECT_NAME}/dotnet)
install_dotnet(test_listener DESTINATION lib/${PROJECT_NAME}/dotnet)

ament_package()
