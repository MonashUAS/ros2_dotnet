// generated from rosidl_generator_cpp/resource/idl__traits.hpp.em
// with input from girbal_msgs:msg/State.idl
// generated code does not contain a copyright notice

#ifndef GIRBAL_MSGS__MSG__DETAIL__STATE__TRAITS_HPP_
#define GIRBAL_MSGS__MSG__DETAIL__STATE__TRAITS_HPP_

#include "girbal_msgs/msg/detail/state__struct.hpp"
#include <rosidl_runtime_cpp/traits.hpp>
#include <stdint.h>
#include <type_traits>

namespace rosidl_generator_traits
{

template<>
inline const char * data_type<girbal_msgs::msg::State>()
{
  return "girbal_msgs::msg::State";
}

template<>
inline const char * name<girbal_msgs::msg::State>()
{
  return "girbal_msgs/msg/State";
}

template<>
struct has_fixed_size<girbal_msgs::msg::State>
  : std::integral_constant<bool, true> {};

template<>
struct has_bounded_size<girbal_msgs::msg::State>
  : std::integral_constant<bool, true> {};

template<>
struct is_message<girbal_msgs::msg::State>
  : std::true_type {};

}  // namespace rosidl_generator_traits

#endif  // GIRBAL_MSGS__MSG__DETAIL__STATE__TRAITS_HPP_
