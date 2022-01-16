// generated from rosidl_generator_c/resource/idl__functions.c.em
// with input from girbal_msgs:msg/State.idl
// generated code does not contain a copyright notice
#include "girbal_msgs/msg/detail/state__functions.h"

#include <assert.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>


bool
girbal_msgs__msg__State__init(girbal_msgs__msg__State * msg)
{
  if (!msg) {
    return false;
  }
  // x
  // y
  // t
  // droneid
  return true;
}

void
girbal_msgs__msg__State__fini(girbal_msgs__msg__State * msg)
{
  if (!msg) {
    return;
  }
  // x
  // y
  // t
  // droneid
}

girbal_msgs__msg__State *
girbal_msgs__msg__State__create()
{
  girbal_msgs__msg__State * msg = (girbal_msgs__msg__State *)malloc(sizeof(girbal_msgs__msg__State));
  if (!msg) {
    return NULL;
  }
  memset(msg, 0, sizeof(girbal_msgs__msg__State));
  bool success = girbal_msgs__msg__State__init(msg);
  if (!success) {
    free(msg);
    return NULL;
  }
  return msg;
}

void
girbal_msgs__msg__State__destroy(girbal_msgs__msg__State * msg)
{
  if (msg) {
    girbal_msgs__msg__State__fini(msg);
  }
  free(msg);
}


bool
girbal_msgs__msg__State__Sequence__init(girbal_msgs__msg__State__Sequence * array, size_t size)
{
  if (!array) {
    return false;
  }
  girbal_msgs__msg__State * data = NULL;
  if (size) {
    data = (girbal_msgs__msg__State *)calloc(size, sizeof(girbal_msgs__msg__State));
    if (!data) {
      return false;
    }
    // initialize all array elements
    size_t i;
    for (i = 0; i < size; ++i) {
      bool success = girbal_msgs__msg__State__init(&data[i]);
      if (!success) {
        break;
      }
    }
    if (i < size) {
      // if initialization failed finalize the already initialized array elements
      for (; i > 0; --i) {
        girbal_msgs__msg__State__fini(&data[i - 1]);
      }
      free(data);
      return false;
    }
  }
  array->data = data;
  array->size = size;
  array->capacity = size;
  return true;
}

void
girbal_msgs__msg__State__Sequence__fini(girbal_msgs__msg__State__Sequence * array)
{
  if (!array) {
    return;
  }
  if (array->data) {
    // ensure that data and capacity values are consistent
    assert(array->capacity > 0);
    // finalize all array elements
    for (size_t i = 0; i < array->capacity; ++i) {
      girbal_msgs__msg__State__fini(&array->data[i]);
    }
    free(array->data);
    array->data = NULL;
    array->size = 0;
    array->capacity = 0;
  } else {
    // ensure that data, size, and capacity values are consistent
    assert(0 == array->size);
    assert(0 == array->capacity);
  }
}

girbal_msgs__msg__State__Sequence *
girbal_msgs__msg__State__Sequence__create(size_t size)
{
  girbal_msgs__msg__State__Sequence * array = (girbal_msgs__msg__State__Sequence *)malloc(sizeof(girbal_msgs__msg__State__Sequence));
  if (!array) {
    return NULL;
  }
  bool success = girbal_msgs__msg__State__Sequence__init(array, size);
  if (!success) {
    free(array);
    return NULL;
  }
  return array;
}

void
girbal_msgs__msg__State__Sequence__destroy(girbal_msgs__msg__State__Sequence * array)
{
  if (array) {
    girbal_msgs__msg__State__Sequence__fini(array);
  }
  free(array);
}
