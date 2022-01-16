// generated from rosidl_typesupport_introspection_cpp/resource/idl__type_support.cpp.em
// with input from girbal_msgs:msg/StateArray.idl
// generated code does not contain a copyright notice

#include "array"
#include "cstddef"
#include "string"
#include "vector"
#include "rosidl_runtime_c/message_type_support_struct.h"
#include "rosidl_typesupport_cpp/message_type_support.hpp"
#include "rosidl_typesupport_interface/macros.h"
#include "girbal_msgs/msg/detail/state_array__struct.hpp"
#include "rosidl_typesupport_introspection_cpp/field_types.hpp"
#include "rosidl_typesupport_introspection_cpp/identifier.hpp"
#include "rosidl_typesupport_introspection_cpp/message_introspection.hpp"
#include "rosidl_typesupport_introspection_cpp/message_type_support_decl.hpp"
#include "rosidl_typesupport_introspection_cpp/visibility_control.h"

namespace girbal_msgs
{

namespace msg
{

namespace rosidl_typesupport_introspection_cpp
{

void StateArray_init_function(
  void * message_memory, rosidl_runtime_cpp::MessageInitialization _init)
{
  new (message_memory) girbal_msgs::msg::StateArray(_init);
}

void StateArray_fini_function(void * message_memory)
{
  auto typed_message = static_cast<girbal_msgs::msg::StateArray *>(message_memory);
  typed_message->~StateArray();
}

size_t size_function__StateArray__states(const void * untyped_member)
{
  const auto * member = reinterpret_cast<const std::vector<int32_t> *>(untyped_member);
  return member->size();
}

const void * get_const_function__StateArray__states(const void * untyped_member, size_t index)
{
  const auto & member =
    *reinterpret_cast<const std::vector<int32_t> *>(untyped_member);
  return &member[index];
}

void * get_function__StateArray__states(void * untyped_member, size_t index)
{
  auto & member =
    *reinterpret_cast<std::vector<int32_t> *>(untyped_member);
  return &member[index];
}

void resize_function__StateArray__states(void * untyped_member, size_t size)
{
  auto * member =
    reinterpret_cast<std::vector<int32_t> *>(untyped_member);
  member->resize(size);
}

static const ::rosidl_typesupport_introspection_cpp::MessageMember StateArray_message_member_array[2] = {
  {
    "states",  // name
    ::rosidl_typesupport_introspection_cpp::ROS_TYPE_INT32,  // type
    0,  // upper bound of string
    nullptr,  // members of sub message
    true,  // is array
    0,  // array size
    false,  // is upper bound
    offsetof(girbal_msgs::msg::StateArray, states),  // bytes offset in struct
    nullptr,  // default value
    size_function__StateArray__states,  // size() function pointer
    get_const_function__StateArray__states,  // get_const(index) function pointer
    get_function__StateArray__states,  // get(index) function pointer
    resize_function__StateArray__states  // resize(index) function pointer
  },
  {
    "angry",  // name
    ::rosidl_typesupport_introspection_cpp::ROS_TYPE_INT32,  // type
    0,  // upper bound of string
    nullptr,  // members of sub message
    false,  // is array
    0,  // array size
    false,  // is upper bound
    offsetof(girbal_msgs::msg::StateArray, angry),  // bytes offset in struct
    nullptr,  // default value
    nullptr,  // size() function pointer
    nullptr,  // get_const(index) function pointer
    nullptr,  // get(index) function pointer
    nullptr  // resize(index) function pointer
  }
};

static const ::rosidl_typesupport_introspection_cpp::MessageMembers StateArray_message_members = {
  "girbal_msgs::msg",  // message namespace
  "StateArray",  // message name
  2,  // number of fields
  sizeof(girbal_msgs::msg::StateArray),
  StateArray_message_member_array,  // message members
  StateArray_init_function,  // function to initialize message memory (memory has to be allocated)
  StateArray_fini_function  // function to terminate message instance (will not free memory)
};

static const rosidl_message_type_support_t StateArray_message_type_support_handle = {
  ::rosidl_typesupport_introspection_cpp::typesupport_identifier,
  &StateArray_message_members,
  get_message_typesupport_handle_function,
};

}  // namespace rosidl_typesupport_introspection_cpp

}  // namespace msg

}  // namespace girbal_msgs


namespace rosidl_typesupport_introspection_cpp
{

template<>
ROSIDL_TYPESUPPORT_INTROSPECTION_CPP_PUBLIC
const rosidl_message_type_support_t *
get_message_type_support_handle<girbal_msgs::msg::StateArray>()
{
  return &::girbal_msgs::msg::rosidl_typesupport_introspection_cpp::StateArray_message_type_support_handle;
}

}  // namespace rosidl_typesupport_introspection_cpp

#ifdef __cplusplus
extern "C"
{
#endif

ROSIDL_TYPESUPPORT_INTROSPECTION_CPP_PUBLIC
const rosidl_message_type_support_t *
ROSIDL_TYPESUPPORT_INTERFACE__MESSAGE_SYMBOL_NAME(rosidl_typesupport_introspection_cpp, girbal_msgs, msg, StateArray)() {
  return &::girbal_msgs::msg::rosidl_typesupport_introspection_cpp::StateArray_message_type_support_handle;
}

#ifdef __cplusplus
}
#endif
