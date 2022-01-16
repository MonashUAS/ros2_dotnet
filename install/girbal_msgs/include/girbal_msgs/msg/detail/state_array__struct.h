// generated from rosidl_generator_c/resource/idl__struct.h.em
// with input from girbal_msgs:msg/StateArray.idl
// generated code does not contain a copyright notice

#ifndef GIRBAL_MSGS__MSG__DETAIL__STATE_ARRAY__STRUCT_H_
#define GIRBAL_MSGS__MSG__DETAIL__STATE_ARRAY__STRUCT_H_

#ifdef __cplusplus
extern "C"
{
#endif

#include <stdbool.h>
#include <stddef.h>
#include <stdint.h>


// Constants defined in the message

// Include directives for member types
// Member 'states'
#include "rosidl_runtime_c/primitives_sequence.h"

// Struct defined in msg/StateArray in the package girbal_msgs.
typedef struct girbal_msgs__msg__StateArray
{
  rosidl_runtime_c__int32__Sequence states;
  int32_t angry;
} girbal_msgs__msg__StateArray;

// Struct for a sequence of girbal_msgs__msg__StateArray.
typedef struct girbal_msgs__msg__StateArray__Sequence
{
  girbal_msgs__msg__StateArray * data;
  /// The number of valid items in data
  size_t size;
  /// The number of allocated items in data
  size_t capacity;
} girbal_msgs__msg__StateArray__Sequence;

#ifdef __cplusplus
}
#endif

#endif  // GIRBAL_MSGS__MSG__DETAIL__STATE_ARRAY__STRUCT_H_
