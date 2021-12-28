<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <h2>What do you wanna do?</h2>
    <div></div>
    <button v-on:click="nav(1)"> Add Songs here</button>
    <button v-on:click="nav(2)"> Vote for your favorite songs</button>
    <button v-on:click="nav(3)"> Show top songs</button>
    
  </div>
</template>

<script>
import router from '../router'
export default {
  name: 'home',
  data () {
    return {
      msg: 'Welome to the Eurosong contest'
    }
  },
  methods:
  {
    nav(i)
    {
      if (i === 1)
      {
        router.push('addSongs');
        
      }
      else if (i === 2)
      {
        router.push('vote');
      }
      else if(i ===3)
      {
        router.push('TopSongs');
      }
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

button
{
  width: 25%;
  height: 200px;
}
</style>
