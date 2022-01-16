// generated from rosidl_generator_dotnet/resource/idl.h.em
// with input from girbal_msgs:msg/State.idl
// generated code does not contain a copyright notice
#ifndef RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_H
#define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_H

#if defined(_MSC_VER)
    //  Microsoft
    #define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_EXPORT __declspec(dllexport)
    #define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_IMPORT __declspec(dllimport)
    #define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_CDECL __cdecl
#elif defined(__GNUC__)
    //  GCC
    #define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_EXPORT __attribute__((visibility("default")))
    #define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_IMPORT
    #define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_CDECL __attribute__((__cdecl__))
#else
    //  do nothing and hope for the best?
    #define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_EXPORT
    #define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_IMPORT
    #define RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_CDECL
    #pragma warning Unknown dynamic link import/export semantics.
#endif

RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_EXPORT
const void * RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_CDECL girbal_msgs__msg__State__get_typesupport();

RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_EXPORT
void * RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_CDECL girbal_msgs__msg__State__create_native_message();

RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_EXPORT
void RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_CDECL girbal_msgs__msg__State__destroy_native_message(void *);

RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_EXPORT
int32_t RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_CDECL girbal_msgs__msg__State__read_field_x(void *);

RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_EXPORT
void girbal_msgs__msg__State__write_field_x(void *, int32_t);
RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_EXPORT
int32_t RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_CDECL girbal_msgs__msg__State__read_field_y(void *);

RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_EXPORT
void girbal_msgs__msg__State__write_field_y(void *, int32_t);
RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_EXPORT
uint32_t RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_CDECL girbal_msgs__msg__State__read_field_t(void *);

RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_EXPORT
void girbal_msgs__msg__State__write_field_t(void *, uint32_t);
RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_EXPORT
uint32_t RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_CDECL girbal_msgs__msg__State__read_field_droneid(void *);

RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_EXPORT
void girbal_msgs__msg__State__write_field_droneid(void *, uint32_t);

#endif // RCLDOTNET_GIRBAL_MSGS_GIRBAL_MSGS_MSG_STATE_H
