#version 330

out vec4 outputColor;

in vec2 texCoord;

uniform sampler2D texture0;
uniform sampler2D texture1;

in vec4 vertexColor;

void main()
{
    outputColor = vertexColor;
}