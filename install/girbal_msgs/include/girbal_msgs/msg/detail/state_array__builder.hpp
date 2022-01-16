// generated from rosidl_generator_cpp/resource/idl__builder.hpp.em
// with input from girbal_msgs:msg/StateArray.idl
// generated code does not contain a copyright notice

#ifndef GIRBAL_MSGS__MSG__DETAIL__STATE_ARRAY__BUILDER_HPP_
#define GIRBAL_MSGS__MSG__DETAIL__STATE_ARRAY__BUILDER_HPP_

#include "girbal_msgs/msg/detail/state_array__struct.hpp"
#include <rosidl_runtime_cpp/message_initialization.hpp>
#include <algorithm>
#include <utility>


namespace girbal_msgs
{

namespace msg
{

namespace builder
{

class Init_StateArray_angry
{
public:
  explicit Init_StateArray_angry(::girbal_msgs::msg::StateArray & msg)
  : msg_(msg)
  {}
  ::girbal_msgs::msg::StateArray angry(::girbal_msgs::msg::StateArray::_angry_type arg)
  {
    msg_.angry = std::move(arg);
    return std::move(msg_);
  }

private:
  ::girbal_msgs::msg::StateArray msg_;
};

class Init_StateArray_states
{
public:
  Init_StateArray_states()
  : msg_(::rosidl_runtime_cpp::MessageInitialization::SKIP)
  {}
  Init_StateArray_angry states(::girbal_msgs::msg::StateArray::_states_type arg)
  {
    msg_.states = std::move(arg);
    return Init_StateArray_angry(msg_);
  }

private:
  ::girbal_msgs::msg::StateArray msg_;
};

}  // namespace builder

}  // namespace msg

template<typename MessageType>
auto build();

template<>
inline
auto build<::girbal_msgs::msg::StateArray>()
{
  return girbal_msgs::msg::builder::Init_StateArray_states();
}

}  // namespace girbal_msgs

#endif  // GIRBAL_MSGS__MSG__DETAIL__STATE_ARRAY__BUILDER_HPP_
