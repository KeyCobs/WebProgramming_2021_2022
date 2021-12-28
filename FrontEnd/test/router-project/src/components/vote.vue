<template>
  <div class="votes">
    <h1>{{ msg }}</h1>
    <a style="cursor: pointer; text-decoration: underline" v-on:click="navigate()">Navigate to home</a>
    <h2 >songs</h2>
    <button class="nav navA" v-on:click="Back()">back</button>
    <h1 style="border-radius: 10px; background: beige; padding: 10px;" class="nav">{{title}}</h1>
    <button class="nav navB" v-on:click="Next()">next</button>
    <h1>Vote</h1>
    <button v-on:click="Vote(1)">1</button>
    <button v-on:click="Vote(2)">2</button>
    <button v-on:click="Vote(3)">3</button>
    <button v-on:click="Vote(4)">4</button>
    <button v-on:click="Vote(5)">5</button>
    <button v-on:click="Vote(6)">6</button>
    <button v-on:click="Vote(7)">7</button>
    <button v-on:click="Vote(8)">8</button>
    <button v-on:click="Vote(9)">9</button>
    <button v-on:click="Vote(10)">10</button>
    <button v-on:click="Vote(11)">11</button>
    <button v-on:click="Vote(12)">12</button>
  </div>
</template>

<script>
//https://localhost:5001/Artist
//https://localhost:5001/Songs
//https://localhost:5001/Vote

    import router from '../router';
    import Vue from 'vue';
    import axioss from 'axios';
    import VueAxios from 'vue-axios' ;
    Vue.use(VueAxios,axioss);
    let currentSongID = 10;
    let SelectedFlag = 'BE';
    let pos = 0;

export default {
  name: 'vote',
  data () {
    return {
    songIDArr:undefined,
    title:undefined,
    msg: 'vote here'
    }
  },
      mounted()
      {
          Vue.axios.get('https://localhost:5001/Songs')
          .then((r)=>
          {
              this.songIDArr = r.data;
              currentSongID = r.data[0].id
          })
          Vue.axios.get('https://localhost:5001/Songs/' + currentSongID)
          .then((r)=>
          {
              this.title = r.data.title;
          })
      },
  methods:
  {
      navigate()
      {
          
          router.go(-1);
      },
        Back()
      {
          let leng = this.songIDArr.length -1;
          if(currentSongID === this.songIDArr[0].id)
          {
            pos = leng;
            currentSongID = this.songIDArr[pos].id;
          }
          else
          {
              --pos;
              currentSongID = this.songIDArr[pos].id;
          }
        Vue.axios.get('https://localhost:5001/Songs/' + currentSongID)
        .then((r)=>
        {
            this.title = r.data.title;
            return this.title;
        })

      },
      Next()
      {
          let leng = this.songIDArr.length -1;
          if(currentSongID === this.songIDArr[leng].id)
          {
            pos = 0;
            currentSongID = this.songIDArr[pos].id;
          }
          else
          {
              ++pos;
              currentSongID = this.songIDArr[pos].id;
          }

        console.log(currentSongID);
        Vue.axios.get('https://localhost:5001/Songs/' + currentSongID)
        .then((r)=>
        {
            this.title = r.data.title;
            return this.title;
        })

      },
      Vote(score)
      {
          let scoreAdd = {song_ID: currentSongID, points: score,incomingPoints: SelectedFlag };
              console.log(scoreAdd);
          Vue.axios.post('https://localhost:5001/Vote',scoreAdd)
          .then(Response => {
              
          })
      }

      /*
       List with all ID 
       Current ID -> Object
       Vote score will change ID
      */
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1, h2 {
  font-weight: normal;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}

.nav
{
    display: inline;
    

}
.navA, .navB
{
   
    
}
</style>
