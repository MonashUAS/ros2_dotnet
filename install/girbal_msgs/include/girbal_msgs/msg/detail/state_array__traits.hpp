// generated from rosidl_generator_cpp/resource/idl__traits.hpp.em
// with input from girbal_msgs:msg/StateArray.idl
// generated code does not contain a copyright notice

#ifndef GIRBAL_MSGS__MSG__DETAIL__STATE_ARRAY__TRAITS_HPP_
#define GIRBAL_MSGS__MSG__DETAIL__STATE_ARRAY__TRAITS_HPP_

#include "girbal_msgs/msg/detail/state_array__struct.hpp"
#include <rosidl_runtime_cpp/traits.hpp>
#include <stdint.h>
#include <type_traits>

namespace rosidl_generator_traits
{

template<>
inline const char * data_type<girbal_msgs::msg::StateArray>()
{
  return "girbal_msgs::msg::StateArray";
}

template<>
inline const char * name<girbal_msgs::msg::StateArray>()
{
  return "girbal_msgs/msg/StateArray";
}

template<>
struct has_fixed_size<girbal_msgs::msg::StateArray>
  : std::integral_constant<bool, false> {};

template<>
struct has_bounded_size<girbal_msgs::msg::StateArray>
  : std::integral_constant<bool, false> {};

template<>
struct is_message<girbal_msgs::msg::StateArray>
  : std::true_type {};

}  // namespace rosidl_generator_traits

#endif  // GIRBAL_MSGS__MSG__DETAIL__STATE_ARRAY__TRAITS_HPP_
