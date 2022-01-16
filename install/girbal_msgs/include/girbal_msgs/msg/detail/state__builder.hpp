// generated from rosidl_generator_cpp/resource/idl__builder.hpp.em
// with input from girbal_msgs:msg/State.idl
// generated code does not contain a copyright notice

#ifndef GIRBAL_MSGS__MSG__DETAIL__STATE__BUILDER_HPP_
#define GIRBAL_MSGS__MSG__DETAIL__STATE__BUILDER_HPP_

#include "girbal_msgs/msg/detail/state__struct.hpp"
#include <rosidl_runtime_cpp/message_initialization.hpp>
#include <algorithm>
#include <utility>


namespace girbal_msgs
{

namespace msg
{

namespace builder
{

class Init_State_droneid
{
public:
  explicit Init_State_droneid(::girbal_msgs::msg::State & msg)
  : msg_(msg)
  {}
  ::girbal_msgs::msg::State droneid(::girbal_msgs::msg::State::_droneid_type arg)
  {
    msg_.droneid = std::move(arg);
    return std::move(msg_);
  }

private:
  ::girbal_msgs::msg::State msg_;
};

class Init_State_t
{
public:
  explicit Init_State_t(::girbal_msgs::msg::State & msg)
  : msg_(msg)
  {}
  Init_State_droneid t(::girbal_msgs::msg::State::_t_type arg)
  {
    msg_.t = std::move(arg);
    return Init_State_droneid(msg_);
  }

private:
  ::girbal_msgs::msg::State msg_;
};

class Init_State_y
{
public:
  explicit Init_State_y(::girbal_msgs::msg::State & msg)
  : msg_(msg)
  {}
  Init_State_t y(::girbal_msgs::msg::State::_y_type arg)
  {
    msg_.y = std::move(arg);
    return Init_State_t(msg_);
  }

private:
  ::girbal_msgs::msg::State msg_;
};

class Init_State_x
{
public:
  Init_State_x()
  : msg_(::rosidl_runtime_cpp::MessageInitialization::SKIP)
  {}
  Init_State_y x(::girbal_msgs::msg::State::_x_type arg)
  {
    msg_.x = std::move(arg);
    return Init_State_y(msg_);
  }

private:
  ::girbal_msgs::msg::State msg_;
};

}  // namespace builder

}  // namespace msg

template<typename MessageType>
auto build();

template<>
inline
auto build<::girbal_msgs::msg::State>()
{
  return girbal_msgs::msg::builder::Init_State_x();
}

}  // namespace girbal_msgs

#endif  // GIRBAL_MSGS__MSG__DETAIL__STATE__BUILDER_HPP_
