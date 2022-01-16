// generated from rosidl_generator_dotnet/resource/idl.h.em
// with input from girbal_msgs:msg/StateArray.idl
// generated code does not contain a copyright notice
#ifndef RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_H
#define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_H

#if defined(_MSC_VER)
    //  Microsoft
    #define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_EXPORT __declspec(dllexport)
    #define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_IMPORT __declspec(dllimport)
    #define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_CDECL __cdecl
#elif defined(__GNUC__)
    //  GCC
    #define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_EXPORT __attribute__((visibility("default")))
    #define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_IMPORT
    #define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_CDECL __attribute__((__cdecl__))
#else
    //  do nothing and hope for the best?
    #define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_EXPORT
    #define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_IMPORT
    #define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_CDECL
    #pragma warning Unknown dynamic link import/export semantics.
#endif

RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_EXPORT
const void * RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_CDECL girbal_msgs__msg__StateArray__get_typesupport();

RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_EXPORT
void * RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_CDECL girbal_msgs__msg__StateArray__create_native_message();

RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_EXPORT
void RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_CDECL girbal_msgs__msg__StateArray__destroy_native_message(void *);

// TODO: Sequence types are not supported
RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_EXPORT
int32_t RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_CDECL girbal_msgs__msg__StateArray__read_field_angry(void *);

RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_EXPORT
void girbal_msgs__msg__StateArray__write_field_angry(void *, int32_t);

#endif // RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATEARRAY_H
