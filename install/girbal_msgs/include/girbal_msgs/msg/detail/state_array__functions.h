// generated from rosidl_generator_c/resource/idl__functions.h.em
// with input from girbal_msgs:msg/StateArray.idl
// generated code does not contain a copyright notice

#ifndef GIRBAL_MSGS__MSG__DETAIL__STATE_ARRAY__FUNCTIONS_H_
#define GIRBAL_MSGS__MSG__DETAIL__STATE_ARRAY__FUNCTIONS_H_

#ifdef __cplusplus
extern "C"
{
#endif

#include <stdbool.h>
#include <stdlib.h>

#include "rosidl_runtime_c/visibility_control.h"
#include "girbal_msgs/msg/rosidl_generator_c__visibility_control.h"

#include "girbal_msgs/msg/detail/state_array__struct.h"

/// Initialize msg/StateArray message.
/**
 * If the init function is called twice for the same message without
 * calling fini inbetween previously allocated memory will be leaked.
 * \param[in,out] msg The previously allocated message pointer.
 * Fields without a default value will not be initialized by this function.
 * You might want to call memset(msg, 0, sizeof(
 * girbal_msgs__msg__StateArray
 * )) before or use
 * girbal_msgs__msg__StateArray__create()
 * to allocate and initialize the message.
 * \return true if initialization was successful, otherwise false
 */
ROSIDL_GENERATOR_C_PUBLIC_girbal_msgs
bool
girbal_msgs__msg__StateArray__init(girbal_msgs__msg__StateArray * msg);

/// Finalize msg/StateArray message.
/**
 * \param[in,out] msg The allocated message pointer.
 */
ROSIDL_GENERATOR_C_PUBLIC_girbal_msgs
void
girbal_msgs__msg__StateArray__fini(girbal_msgs__msg__StateArray * msg);

/// Create msg/StateArray message.
/**
 * It allocates the memory for the message, sets the memory to zero, and
 * calls
 * girbal_msgs__msg__StateArray__init().
 * \return The pointer to the initialized message if successful,
 * otherwise NULL
 */
ROSIDL_GENERATOR_C_PUBLIC_girbal_msgs
girbal_msgs__msg__StateArray *
girbal_msgs__msg__StateArray__create();

/// Destroy msg/StateArray message.
/**
 * It calls
 * girbal_msgs__msg__StateArray__fini()
 * and frees the memory of the message.
 * \param[in,out] msg The allocated message pointer.
 */
ROSIDL_GENERATOR_C_PUBLIC_girbal_msgs
void
girbal_msgs__msg__StateArray__destroy(girbal_msgs__msg__StateArray * msg);


/// Initialize array of msg/StateArray messages.
/**
 * It allocates the memory for the number of elements and calls
 * girbal_msgs__msg__StateArray__init()
 * for each element of the array.
 * \param[in,out] array The allocated array pointer.
 * \param[in] size The size / capacity of the array.
 * \return true if initialization was successful, otherwise false
 * If the array pointer is valid and the size is zero it is guaranteed
 # to return true.
 */
ROSIDL_GENERATOR_C_PUBLIC_girbal_msgs
bool
girbal_msgs__msg__StateArray__Sequence__init(girbal_msgs__msg__StateArray__Sequence * array, size_t size);

/// Finalize array of msg/StateArray messages.
/**
 * It calls
 * girbal_msgs__msg__StateArray__fini()
 * for each element of the array and frees the memory for the number of
 * elements.
 * \param[in,out] array The initialized array pointer.
 */
ROSIDL_GENERATOR_C_PUBLIC_girbal_msgs
void
girbal_msgs__msg__StateArray__Sequence__fini(girbal_msgs__msg__StateArray__Sequence * array);

/// Create array of msg/StateArray messages.
/**
 * It allocates the memory for the array and calls
 * girbal_msgs__msg__StateArray__Sequence__init().
 * \param[in] size The size / capacity of the array.
 * \return The pointer to the initialized array if successful, otherwise NULL
 */
ROSIDL_GENERATOR_C_PUBLIC_girbal_msgs
girbal_msgs__msg__StateArray__Sequence *
girbal_msgs__msg__StateArray__Sequence__create(size_t size);

/// Destroy array of msg/StateArray messages.
/**
 * It calls
 * girbal_msgs__msg__StateArray__Sequence__fini()
 * on the array,
 * and frees the memory of the array.
 * \param[in,out] array The initialized array pointer.
 */
ROSIDL_GENERATOR_C_PUBLIC_girbal_msgs
void
girbal_msgs__msg__StateArray__Sequence__destroy(girbal_msgs__msg__StateArray__Sequence * array);

#ifdef __cplusplus
}
#endif

#endif  // GIRBAL_MSGS__MSG__DETAIL__STATE_ARRAY__FUNCTIONS_H_
