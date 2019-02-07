<template>
    <div  id="tickets">
<!--
      <div id="overlay" v-on:click="CloseOverlay()">
        <div id="text">Overlay Text</div>
      </div>
-->

      <b-list-group class="justify-content-between align-items-center">
        <b-list-group-item class="show" button v-for="ticket in tickets">
          <div class="show-date ">
            <div class="day">20</div>
            <div class="month">JAN</div>
          </div>
          <div class="show-info">
            <div class="show-name">
              {{ ticket.EventName }}
            </div>
          </div>
        </b-list-group-item>
      </b-list-group>

          </div>
      </template>

      <script>
          export default {
              name: "Tickets",

            data() {
                return {
                  tickets: [
                    {Date:'02 JANV', EventName: 'Céline Dion'},
                    {Date:'29 MAI', EventName: 'Blue man group'},
                    {Date:'31 DÉC', EventName: 'Bones'}
                  ],
                  months: {
                    1: "JAN",
                    2: "FÉV",
                    3: "MAR",
                    4: "AVR",
                    5: "MAI",
                    6: "JUN",
                    7: "JUL",
                    8: "AOÛ",
                    9: "SEP",
                    10: "OCT",
                    11: "NOV",
                    12: "DÉC",
                  }
                }
            },

            methods:
              {
                CloseOverlay()
                {
                  document.getElementById("overlay").style.display = "none";
                },
                OpenOverlay()
                {
                   document.getElementById("overlay").style.display = "block";
                }
              }
          }

      </script>

      <style scoped>

        .show{
          height: 150px;
          width: 1000px;
          padding: 0px;
          margin-bottom: 20px;
        }
        .show-date{
          width: 20%;
          height: 100%;
          float: left;
          background-color: aquamarine;
        }

        .day{
          margin:0;
          position:relative;
          height: 70%;
          color: black;
          font-size: 70px;
        }

        .month{
          top: 70%;
          font-size: 30px;
          font-weight: bold;
        }

        .show-info{
          width:80%;
          float: right;
          height:100%;
        }

        .show-name{
          font-size: 50px;
          position: relative;
          top:25%;

        }

      </style>
