// generated from rosidl_generator_c/resource/idl__struct.h.em
// with input from girbal_msgs:msg/State.idl
// generated code does not contain a copyright notice

#ifndef GIRBAL_MSGS__MSG__DETAIL__STATE__STRUCT_H_
#define GIRBAL_MSGS__MSG__DETAIL__STATE__STRUCT_H_

#ifdef __cplusplus
extern "C"
{
#endif

#include <stdbool.h>
#include <stddef.h>
#include <stdint.h>


// Constants defined in the message

// Struct defined in msg/State in the package girbal_msgs.
typedef struct girbal_msgs__msg__State
{
  int32_t x;
  int32_t y;
  uint32_t t;
  uint32_t droneid;
} girbal_msgs__msg__State;

// Struct for a sequence of girbal_msgs__msg__State.
typedef struct girbal_msgs__msg__State__Sequence
{
  girbal_msgs__msg__State * data;
  /// The number of valid items in data
  size_t size;
  /// The number of allocated items in data
  size_t capacity;
} girbal_msgs__msg__State__Sequence;

#ifdef __cplusplus
}
#endif

#endif  // GIRBAL_MSGS__MSG__DETAIL__STATE__STRUCT_H_
